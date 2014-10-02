z/**
 * Creates an Audiogram
 * @constructor
 * @param {String} id - the DOM id of the HTML input element
 */

function Audiogram(id) {
    this.id; // id of the DOM Element container
    this.el; // DOM Element object of the container
    this.svg; // DOM Element object of the SVG object
    this.r; // Raphael paper element

    this.width; // width of the SVG canvas
    this.height; // height of the SVG canvas
    this.chartWidth; // width of the chart grid
    this.chartHeight; // height of the chart grid

    this.AC; // Raphael set of SVG elements of the air conduction points
    this.BC; // Raphael set of SVG elements of the bone conduction points

	this.iylabels = ['','','','','','','','','','','','','',''];                              // Invisible labels for the invisible lines
    this.ylabels = [-10, 0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130];          // dB HL labels for the y-axis
    this.xlabels = [125, '', 250, '', 500, 750, 1000, 1500, 2000, 3000, 4000, 6000, 8000];    // frequency labels for the x-axis

    /**
     * Draws the gridlines, labels, and titles of the graph
     * @param {Number} height - height of the gridded chart
     */

    this.draw = function (height) {
        var strokeWidth = 1;
		var istrokeWidth = 0;
        
        var STROKE_WIDTH = {"stroke-width": strokeWidth, "stroke": "#000000"};
        var TWICE_STROKE_WIDTH = {"stroke-width": 2 * strokeWidth, "stroke": "#000000"};
        
        this.gutter = height / 8; //width of gutter for labels
        var gutter = this.gutter;

		var inumY = this.iylabels.length;  //number of invisible labels
        var numY = this.ylabels.length;    //number of y-labels
        var numX = this.xlabels.length;    //number of x-labels

        this.chartHeight = height;  //height of the gridded chart itself
        this.diffHeight = (this.chartHeight - 2 * strokeWidth) / (numY - 1);
        var diffHeight = this.diffHeight;
        this.diffWidth = this.diffHeight;
        var diffWidth = diffHeight;
        this.chartWidth = diffWidth * (numX - 1) + 2 * strokeWidth; //width of the gridded chart itself

        this.width = this.chartWidth + 2 * gutter;  //width of the SVG canvas
        this.height = this.chartHeight + 2 * gutter;    //height of the SVG canvas

        this.r = new Raphael(this.id, this.width, this.height);

        this.r.path(Raphael.format("M{0} {1}L{0} {2}", gutter / 2, gutter, this.chartHeight + gutter)).attr(TWICE_STROKE_WIDTH);

        this.r.path(Raphael.format("M{0} {1}L{0} {2}", this.chartWidth + 2 * gutter - gutter / 2, gutter, this.chartHeight + gutter)).attr(TWICE_STROKE_WIDTH);

        this.r.text(this.width / 2, gutter / 4, "Frequency [Hz]").attr({stroke: "#000000"});
        this.r.text(this.width - gutter / 4, this.height / 2, "Hearing Loss in DB HL").transform("r90").attr({stroke: "#000000"});

        /*************************************
         *** DRAW VISIBLE HORIZONTAL LINES ***
         *************************************/

        var positionY = gutter + strokeWidth; //y-coordinate for current line

        for (var i = 0; i < numY; i++) {
            var attr = ( i == 0 || i == numY - 1 ) ? TWICE_STROKE_WIDTH : STROKE_WIDTH ;

            var path = Raphael.format("M{0} {2}L{1} {2}", gutter / 2, this.chartWidth + 1.5 * gutter, positionY);
            this.r.path(path).attr(attr);
            this.r.text(gutter / 2 - gutter / 4, positionY, this.ylabels[i]).attr({stroke: "#000000"});
            positionY += diffHeight;
        }
		
		/***************************************
         *** DRAW INVISIBLE HORIZONTAL LINES ***
         ***************************************/
		 
		 var ipositionY = gutter + istrokeWidth + diffHeight / 2; //y-coordinate for current line
		 
		 for (var i = 0; i < inumY; i++) {
			var attr = (i == 0 || i == inumY - 1) ? TWICE_STROKE_WIDTH : STROKE_WIDTH;
			
			var path = Raphael.format("M{0} {2}L{1} {2}", gutter / 2, this.chartWidth + 1.5 * gutter, ipositionY);
			this.r.path(path).attr(attr);
			ipositionY += diffHeight;
		 }
		
        /***************************
         *** DRAW VERTICAL LINES ***
         ***************************/

        var positionX = gutter + strokeWidth; //x-coordinate for current line

        for (var i = 0; i < numX; i++) {
            var path = Raphael.format("M{1} {0}L{1} {2}", gutter, positionX, this.chartHeight + gutter);
            var attr = (i % 2) ? {"stroke": "#000000", "stroke-dasharray": "."} : STROKE_WIDTH;

            var label_position = (i % 2) ? this.height - 3/4*gutter : (3 / 4 * gutter);

            if (this.xlabels[i] != '') {
                this.r.path(path).attr(attr);
                this.r.text(positionX, label_position, this.xlabels[i]).attr({stroke: "#000000"});
            }
            positionX += diffWidth;
        }

    };

    /**
     * Plots a circle at the given (x, y) coordinates and adds it to the points collection
     * @param {Number} x - x-coordinate of the point
     * @param {Number} y - t-coordinate of the point
     * @param {Number} f - corresponding frequency of the x-coordinate
     * @param {Number} h - cooresponding HL of the y-coordinate
     */

    this.plotAC = function (x, y, f, h) {
        var r = 5 + Math.round(this.height/200); // radius of circle

        var point = this.r.circle(x, y, r).attr({
            "stroke-width": 2,
            'stroke': "#000000"
        });

        point.frequency = f;
        point.HL = h;

        //console.log("x: ", x, "y: ", y);
        this.AC.push(point);
    };

    /**
     * Plots a triangle at the given (x, y) coordinates and adds it to the points collection
     * @param {Number} x - x-coordinate of the point
     * @param {Number} y - t-coordinate of the point
     * @param {Number} f - corresponding frequency of the x-coordinate
     * @param {Number} h - cooresponding HL of the y-coordinate
     */

    this.plotBC = function (x, y, f, h) {
        var r = 5 + Math.round(this.height/200); // "radius" of triangle
        var path = Raphael.format("M{0} {1}L{2} {3}L{4} {5}L{6} {7}", x, y - r, x - r, y + r, x + r, y + r, x, y - r);

        var point = this.r.path(path).attr({
            "stroke-width": 2,
            "stroke-linecap": "round",
            "stroke-linejoin": "miter",
            'stroke': "#000000"
        });

        point.frequency = f;
        point.HL = h;
        point.attrs.cx = x; // manually set center of triangle b/c it's not a built-in shape
        point.attrs.cy = y;

        this.BC.push(point);
    };

    /**
     * Clears all the points plotted on the audiogram
     */

    this.clearPoints = function () {
        this.AC.remove();
        this.BC.remove();
    };

    /**
     * Determines if the given point is within the gridlines
     * @param {Number} x - x-coordinate of the point
     * @param {Number} y - t-coordinate of the point
     * @returns {Boolean}
     */

    this.onGrid = function (x, y) {
        var xGood = x >= this.gutter && x <= (this.width - this.gutter);    // is the x-coordinate within the plottable area?
        var yGood = y >= this.gutter && y <= (this.height - this.gutter);   // is the y-coordinate within the plottable area?
        return xGood && yGood;
    };

    /**
     * Removes any present points at the same x value (frequency) in the current plotType
     * @param {Number} x - x-coordinate of the point
     * @returns {Boolean}
     */

    this.removePoint = function (x) {

        var remove = function(point) {
            if (point !== undefined && point.attrs.cx == x) 
            {
                this.exclude(point);
                point.remove();
            }
        };

        this.plotType == "AC" ? this.AC.forEach(remove, this.AC) : this.BC.forEach(remove, this.BC);
    };

    /**
     * Switches plot type between AC and BC
     * @returns {Audiogram Object}
     */

    this.switchPlotType = function() {
        console.log("current plotType ", this.plotType);
        this.plotType = (this.plotType == "AC") ? "BC": "AC";
        return this; // chain calls
    }.bind(this);


    /**
     * Exports all (x, y) plotted points into (Frequency, dB HL) points
     * Format: { AC: [{f: 125, h: 10}, ...], BC: [{f: 125, h: 10}, ...] }
     * @returns {Object}
     */

    this.exportPoints = function() {
        var obj = {};
        obj.AC = [];
        obj.BC = [];

        this.AC.forEach(function(point) {
            obj.AC.push({f: point.frequency, h: point.HL});
        }, this.AC);

        this.BC.forEach(function(point) {
            obj.BC.push({f: point.frequency, h: point.HL});
        }, this.BC);

        return obj;
    };

    /**
     * Determines the closest point on the grid to the clicked location
     * @param {Number} x - x-coordinate of the point
     * @param {Number} y - t-coordinate of the point
     * @returns {Boolean}
     */

    this.closestPoint = function (x, y) {
        x = x - this.gutter;
        y = y - this.gutter;

        var positionX = Math.round(x / this.diffWidth);
        var positionY = Math.round(y / this.diffHeight);

        var f = this.xlabels[positionX];
        var h = this.ylabels[positionY];

        (positionX <= 4 && positionX % 2) && (positionX--); // if it falls in the first 4 and it's even, then

        x = Math.round(positionX * this.diffWidth + this.gutter + 1);
        y = Math.round(positionY * this.diffHeight + this.gutter + 1);

        //console.log("x = ", positionX, "y = ", positionY, "f = ", f, "h = ", h);

        this.removePoint(x); // remove any points currently at this frequency for the current plotType
        this.plotType == "AC" ? this.plotAC(x, y, f, h) : this.plotBC(x, y, f, h);  // plot a point of the current plot type at the position

        //console.log("diffWidth: ", this.diffWidth, "diffHeight:", this.diffHeight)
        //console.log("x: ", positionX, "y: ", positionY)
    };

    /**
     * Handles events
     * @see https://developer.mozilla.org/en-US/docs/Web/API/EventTarget.addEventListener#The_value_of_this_within_the_handler
     * @param {EventObject}
     */

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
                this.isMouseDown = false;
                break;
            case "click":
                this.onGrid(x, y) && this.closestPoint(x, y);
                break;
        }
    };

    /**
     * Calls the individual functions of the audiogram to draw it and set up event listeners
     */

    this.initialize = function (id, size) {
        this.id = id;
        this.el = document.getElementById(id);
        this.plotType = "AC";
        
        this.draw(size);
        
        this.svg = this.el.querySelector("svg");
        this.AC = this.r.set();
        this.BC = this.r.set();

        this.svg.addEventListener("click", this, false);
        this.svg.addEventListener("mousedown", this, false);
        this.svg.addEventListener("mouseup", this, false);

        return this;
    };
}