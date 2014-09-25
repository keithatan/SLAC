/**************************************************************************
 ** Class RangeInput
 **
 **
 **************************************************************************/

function RangeInput(id) {
    this.el = document.getElementById(id);
    this.val = this.el.value;
    this.handlerFunction;
    this.handerObj;

    /*************************************************************************
     ** Determines the change of the range input element's value
     ** Stores the current value so it can be compared with the next new value
     *
     ** Inputs: none
     ** Outputs: integer of the value change
     **************************************************************************/

    this.handleEvent = function (event) {
        if (event.type !== "change") {
            return;
        };
        var change = parseInt(this.el.value, 10) - parseInt(this.val, 10);
        this.handlerFunction.call(this.handlerObj, change);
        this.val = this.el.value; //store the current value
    };

    /**************************************************************************
     ** Returns an integer of the current value of the range input element
     *
     ** Inputs: none
     ** Outputs: integer of current value
     **************************************************************************/

    this.getValue = function () {
        return parseInt(this.val);
    };

    /**************************************************************************
     ** Registers an event handler function for the "onchange" event
     ** Calls the event handler with the value of the range's change
     **
     ** Inputs: obj = "this" scope to call the 
     **         handler = event handler to be called when the range's value changes
     ** Outputs: none
     **************************************************************************/

    this.subscribe = function (obj, handler) {
        this.handlerFunction = handler;
        this.handlerObj = obj;
        this.el.addEventListener("change", this, false);

        /**************************************************************************
         ** "this" only has scope of RangeInput object two functions deep, but 
         ** calling function "bind" with argument "this" binds the "this" of the
         ** three-deep function to the "RangeInput" object
         **************************************************************************/
    };

    return this; //return "this" object so that we can chain function calls
}

/**************************************************************************
 ** Class DecibelChart
 **
 **
 **************************************************************************/

function DecibelChart(id, width, height) {
    this.gutter;
    this.width = width;
    this.height = height;
    this.paper = Raphael(id, width + 2, height + 2);
    this.dB;
    this.meter;
    this.input;

    /**************************************************************************
     ** 
     **************************************************************************/

    this.initialize = function () {
        this.paper.rect(1, 1, this.width, this.height, 0).attr({
            "fill": "gray"
        });
    };

    /**************************************************************************
     ** 
     **************************************************************************/

    this.drawMeter = function () {
        this.meter && this.meter.remove(); //shortcut if statement

        var path = Raphael.format("M{0} 1L{0} {1}", this.dB + 1, this.height);
        this.meter = this.paper.path(path).attr({
            "stroke": "lightgray",
            "stroke-width": 1
        });
    };

    /**************************************************************************
     ** Increments this.dB by dB_change and then calls this.drawMeter to redraw meter
     ** Inputs: dB_change
     ** Outputs: none
     **************************************************************************/

    this.incrementDecibels = function (dB_change) {
        this.dB = this.dB + dB_change;
        this.drawMeter();
    };

    /**************************************************************************
     ** Inputs: none
     ** Outputs: integer of the value change 
     **************************************************************************/

    this.registerInput = function (input) {
        this.input = input.subscribe(this, this.incrementDecibels);
        this.dB = input.getValue();
    }

    this.initialize();
    return this; //return "this" object so that we can chain function calls
}

/**************************************************************************
 ** Class Audiogram
 **
 **
 **************************************************************************/

function Audiogram(id) {
    this.id = id; // id of the DOM Element container
    this.el = document.getElementById(id); // Element object of the container
    this.svg; // Element object of the SVG object
    this.r; // Raphael paper element

    this.width; // width of the SVG canvas
    this.height; // height of the SVG canvas
    this.chartWidth; // width of the chart grid
    this.chartHeight; // height of the chart grid

    this.points; // Raphael set of svg elements of the points

    /**************************************************************************
     ** Draws the gridlines, labels, and titles of the graph
     **************************************************************************/

    this.draw = function () {
        this.gutter = gutter = 50; //width of gutter for labels
        const strokeWidth = 1; //width of each line

        const ylabels = [-10, 0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130];
        const xlabels = [125, 250, 500, 1000, 2000, 4000, 8000];

        const numY = ylabels.length;
        const numX = xlabels.length;

        this.chartHeight = 400;
        var diffHeight = (this.chartHeight - 2 * strokeWidth) / (numY - 1);
        var diffWidth = 2 * diffHeight;
        this.chartWidth = diffWidth * (numX - 1) + 2 * strokeWidth;

        this.width = this.chartWidth + 2 * gutter;
        this.height = this.chartHeight + 2 * gutter;

        this.r = Raphael(this.id, this.width, this.height);

        this.r.path(Raphael.format("M{0} {1}L{0} {2}", gutter / 2, gutter, this.chartHeight + gutter))
            .attr({
            "stroke-width": 2 * strokeWidth
        });
        this.r.path(Raphael.format("M{0} {1}L{0} {2}", this.chartWidth + 2 * gutter - gutter / 2, gutter, this.chartHeight + gutter))
            .attr({
            "stroke-width": 2 * strokeWidth
        });

        this.r.text(this.width / 2, gutter / 4, "Frequency [Hz]");
        this.r.text(this.width - gutter / 4, this.height / 2, "Hearing Loss in DB HL").transform("r90");

        /****************************
         ** DRAW HORIZONTAL LINES
         ****************************/

        var positionY = gutter + strokeWidth; //y-coordiante for current line

        for (i = 0; i < numY; i++) {
            if (i == 0 || i == numY - 1) {
                var attr = {
                    "stroke": "#000000",
                    "stroke-width": 2 * strokeWidth
                };
            } else {
                var attr = {
                    "stroke": "#000000"
                };
            }
            var path = Raphael.format("M{0} {2}L{1} {2}", gutter / 2, this.chartWidth + 1.5 * gutter, positionY);
            this.r.path(path).attr(attr);
            this.r.text(gutter / 2 - gutter / 4, positionY, ylabels[i]);
            positionY += diffHeight;
        }

        /****************************
         ** DRAW VERTICAL LINES
         ****************************/

        var positionX = gutter + strokeWidth; //x-coordinate for current line

        for (i = 0; i < numX; i++) {
            var path = Raphael.format("M{1} {0}L{1} {2}", gutter, positionX, this.chartHeight + gutter);
            this.r.path(path).attr({
                "stroke": "#000000"
            });
            this.r.text(positionX, gutter / 2 + gutter / 4, xlabels[i]);
            positionX += diffWidth;
        }

    };

    /**************************************************************************
     ** Plots a circle at the given (x, y) coordinates
     ** Inputs: x = x-coordinate of point
     **         y = y-coordinate of point
     **************************************************************************/

    this.plotCircle = function (x, y) {
        var point = this.r.circle(x, y, 5).attr({
            "stroke-width": 3
        });
        
        point.x = x;
        point.y = y;
        
        this.points.push(point);
    };

    /**************************************************************************
     ** Plots a triangle at the given (x, y) coordinates
     ** Inputs: x = x-coordinate of point
     **         y = y-coordinate of point
     **************************************************************************/

    this.plotTriangle = function (x, y) {
        var path = Raphael.format("M{0} {1}L{2} {3}L{4} {5}L{6} {7}", x, y - 5, x - 5, y + 5, x + 5, y + 5, x, y - 5);
        var point = this.r.path(path).attr({
            "stroke-width": 2,
            "stroke-linecap": "round",
            "stroke-linejoin": "miter"
        });

        point.x = x;
        point.y = y;
        
        this.points.push(point);
    };

    /**************************************************************************
     ** Removes all plotted points
     **************************************************************************/

    this.clearPoints = function () {
        this.points.remove();
    };
    
    /**************************************************************************
     ** Draw a rectangle previewing points to be deleted
     **************************************************************************/

    this.previewSelection = function (x, y) {
        this.previewRect && this.previewRect.remove();
        
        var width = x - this.start.x;
        var height = y - this.start.y;
        
        var plot = {};
        plot.x = this.start.x;
        plot.y = this.start.y;
        
        if (width < 0) {
            width = -width;
            plot.x = x;
        }
        if (height < 0) {
            height = -height;
            plot.y = y;
        }
        
        this.previewRect = this.r.rect(plot.x, plot.y, width, height).attr({"stroke": "#000000", "stroke-dasharray": "-"});
    };
                    
    /**************************************************************************
     ** Delete points that fall within the preview box
     **************************************************************************/

    this.deleteSelection = function (x, y) {
        
        if(!this.previewRect) { return; }
        var BBox = this.previewRect.getBBox();
        
        this.points.forEach(function(point) {
            Raphael.isPointInsideBBox(BBox, point.x, point.y) && point.remove();
        });
        this.previewRect && this.previewRect.remove();
    };

    /**************************************************************************
     ** Determine if the given point is within the gridlines
     ** Inputs: x = x-coordinate of point
     **         y = y-coordinate of point
     ** Outputs: Boolean
     **************************************************************************/

    this.onGrid = function (x, y) {
        var xGood = x >= this.gutter && x <= (this.width - this.gutter);
        var yGood = y >= this.gutter && y <= (this.height - this.gutter);
        return xGood && yGood;
    };

    /**************************************************************************
     ** handleEvent function 
     ** see: https://developer.mozilla.org/en-US/docs/Web/API/EventTarget.addEventListener#The_value_of_this_within_the_handler
     **************************************************************************/

    this.handleEvent = function (event) {
        event.preventDefault();
        var x = event.offsetX;
        var y = event.offsetY;

        switch (event.type) {
            case "mousedown":
                this.isMouseDown = true;
                this.start = {"x": x, "y": y};
                break;
            case "mouseup":
                this.deleteSelection(x, y);
                this.isMouseDown = false;
                break;
            case "click":
                this.onGrid(x, y) && this.plotTriangle(x, y);
                break;
            case "mousemove":
                this.isMouseDown && this.previewSelection(x, y);
                break;
        }
    };

    /**************************************************************************
     ** 
     **************************************************************************/

    this.initialize = function () {
        this.draw();
        this.svg = this.el.querySelector("svg");
        this.points = this.r.set();
        
        this.svg.addEventListener("click", this, false);
        this.svg.addEventListener("mousedown", this, false);
        this.svg.addEventListener("mouseup", this, false);
        this.svg.addEventListener("mousemove", this, false);
    };

    this.initialize();
}

/**************************************************************************
 ** Calls the functions that draw the components of the app
 ** Registers input elements for the components
 **************************************************************************/

var initializeApp = function () {
    window.chartLeft = new DecibelChart("chart1", 200, 50).registerInput(new RangeInput("range1"));
    window.chartRight = new DecibelChart("chart2", 200, 50).registerInput(new RangeInput("range2"));
    window.audiogram = new Audiogram("audiogram");
}

var loadData = function (data) {
    window.patients = data.patients;
}

/**************************************************************************
 ** Begins execution by listening to see when the page has loaded
 ** Executes "initializeApp" function at that point
 **************************************************************************/

window.addEventListener("load", initializeApp, false);