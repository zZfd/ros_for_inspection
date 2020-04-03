/**
 * @author Russell Toris - rctoris@wpi.edu
 */

/**
 * A map that listens to a given occupancy grid topic.
 *
 * Emits the following events:
 *   * 'change' - there was an update or change in the map
 *
 * @constructor
 * @param options - object with following keys:
 *   * ros - the ROSLIB.Ros connection handle
 *   * topic (optional) - the map topic to listen to
 *   * rootObject (optional) - the root object to add this marker to
 *   * continuous (optional) - if the map should be continuously loaded (e.g., for SLAM)
 */
ROS2D.OccupancyGridClient = function(options) {
  var that = this;
  options = options || {};
  var ros = options.ros;
  var topic = options.topic || '/map';
  this.continuous = options.continuous;
  this.rootObject = options.rootObject || new createjs.Container();//放置地图的容器

  // current grid that is displayed
  // create an empty shape to start with, so that the order remains correct.
  this.currentGrid = new createjs.Shape();
  // this.currentGrid2 = new createjs.Shape();
  this.rootObject.addChild(this.currentGrid);
  // this.rootObject.addChild(this.currentGrid2);
  // work-around for a bug in easeljs -- needs a second object to render correctly
  //this.rootObject.addChild(new ROS2D.Grid({size:1}));
  // this.rootObject.addChild(new ROS2D.Grid({size:2}));

  // subscribe to the topic
  var rosTopic = new ROSLIB.Topic({
    ros : ros,
    name : topic,
    messageType : 'nav_msgs/OccupancyGrid',
    compression : 'png'
  });

  rosTopic.subscribe(function(message) {//只需要message地图元数据
    // check for an old map
    var index = null;
    if (that.currentGrid) {
      index = that.rootObject.getChildIndex(that.currentGrid);
      //console.log('This currentGrid index:' + index);
      that.rootObject.removeChild(that.currentGrid);
    }

    that.currentGrid = new ROS2D.OccupancyGrid({
      message : message
    });//生成地图
    // that.currentGrid2 = new ROS2D.OccupancyGrid({
    //   message : message
    // });
    if (index !== null) {
      that.rootObject.addChildAt(that.currentGrid, index);
      var shape = new createjs.Shape();
      var graphics = new createjs.Graphics();
      graphics.setStrokeStyle(0.1);
      graphics.beginStroke('red');
      graphics.moveTo(0.0,0.0);
      graphics.lineTo(1.0,0.0);
      graphics.endFill();
      shape.graphics = graphics;
      // shape.graphics.beginFill('red').drawCircle(5,5,5,5);
      // shape.graphics.endFill();
      that.rootObject.addChildAt(shape,index+1);
      console.log('我添加了:' + that.rootObject.getChildIndex(that.currentGrid));
      console.log('我添加了:' + that.rootObject.getChildIndex(shape));
      // console.log('map index:'+ that.rootObject.getChildIndex(that.currentGrid));
      // that.rootObject.addChildAt(that.currentGrid2, index+1);
      // var shape = new createjs.Shape();
      // shape.graphics.beginFill('red').drawCircle(0, 0, 80, 80);
      // shape.graphics.endFill();
      // that.rootObject.addChildAt(shape, index);
      // that.rootObject.addChildAt(shape, index);
      // console.log('我新添加了一个图像!'+that.rootObject.getChildIndex(shape));
      // that.rootObject.update();
      
    }
    else {
      that.rootObject.addChild(that.currentGrid);
      var shape = new createjs.Shape();
      shape.graphics.beginFill('red').drawCircle(5,5,5,5);
      shape.graphics.endFill();
      that.rootObject.addChild(shape);
      console.log('我添加了else:' + that.rootObject.getChildIndex(that.currentGrid));
      console.log('我添加了else:' + that.rootObject.getChildIndex(shape));
    }

    that.emit('change');

    // check if we should unsubscribe
    if (!that.continuous) {
      rosTopic.unsubscribe();
    }
  });
};
ROS2D.OccupancyGridClient.prototype.__proto__ = EventEmitter2.prototype;