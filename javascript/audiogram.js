// Creates an Audiogram
function Audiogram(id) {
    this.id; // id of the DOM Element container
    this.el; // DOM Element object of the container
    this.svg; // DOM Element object of the SVG object
    this.r; // Raphael paper element

    this.width; // width of the SVG canvas
    this.height; // height of the SVG canvas
    this.chartWidth; // width of the chart grid
    this.chartHeight; // height of the chart grid
	
	// Raphael sets of SVG elements for Air Conduction points
    this.AC_L = new Array();
	this.AC_R = new Array();
	this.AC_NR_L = new Array();
	this.AC_NR_R1 = new Array();
	this.AC_NR_R2 = new Array();
	this.AC_M_L = new Array();
	this.AC_M_R = new Array();
	this.AC_M_NR_L = new Array();
	this.AC_M_NR_R = new Array();
	
	// Raphael sets of SVG elements for Bone Conduction points
    this.BC_L = new Array();
	this.BC_R = new Array();
	this.BC_NR_L = new Array();
	this.BC_NR_R = new Array();
	this.BC_M_L = new Array();
	this.BC_M_R = new Array();
	this.BC_M_NR_L = new Array();
	this.BC_M_NR_R = new Array();
	
	// Raphael sets of SVG elements for Uncomfortable Level points
	this.UL_R = new Array();
	this.UL_L = new Array();

    this.ylabels = [-10, 0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130];       // dB HL labels for the y-axis
    this.xlabels = [125, '', 250, '', 500, ' ', 1000, ' ', 2000, ' ', 4000, ' ', 8000];    // frequency labels for the x-axis
	
	this.frequencies = [125, 125, 250, 250, 500, 750, 1000, 1500, 2000, 3000, 4000, 6000, 8000];

	// Draws the gridlines, labels, and titles of the audiogram
    this.draw = function (height) {
        var strokeWidth = 1; // width of the lines drawn on the graph
        
        var STROKE_WIDTH = {"stroke-width": strokeWidth, "stroke": "#000000"};
        var TWICE_STROKE_WIDTH = {"stroke-width": 2 * strokeWidth, "stroke": "#000000"};
        
        this.gutter = height / 8; // width of gutter for labels
        var gutter = this.gutter;
		// NOTE: Still not exactly sure what the "gutter" is. If you know, update me please. -HH

        var numY = this.ylabels.length;    // number of y-labels
        var numX = this.xlabels.length;    // number of x-labels

        this.chartHeight = height;  // height of the gridded chart itself
        this.diffHeight = ((this.chartHeight - 2 * strokeWidth) / (numY - 1)) / 2; // distance between y-axis values
        var diffHeight = this.diffHeight;
        this.diffWidth = this.diffHeight * 2; // distance between x-axis values
        var diffWidth = diffHeight * 2;
        this.chartWidth = diffWidth * (numX - 1) + 2 * strokeWidth; // width of the gridded chart itself

        this.width = this.chartWidth + 2 * gutter;  // width of the SVG canvas
        this.height = this.chartHeight + 2 * gutter;    // height of the SVG canvas

        this.r = new Raphael(this.id, this.width, this.height); // Raphael SVG canvas

        this.r.path(Raphael.format("M{0} {1}L{0} {2}", gutter / 2, gutter, this.chartHeight + gutter)).attr(TWICE_STROKE_WIDTH);

        this.r.path(Raphael.format("M{0} {1}L{0} {2}", this.chartWidth + 2 * gutter - gutter / 2, gutter, this.chartHeight + gutter)).attr(TWICE_STROKE_WIDTH);

        this.r.text(this.width / 2, gutter
         / 4, "Frequency [Hz]").attr({stroke: "#000000"});
        this.r.text(this.width - gutter / 4, this.height / 2, "Hearing Loss in DB HL").transform("r90").attr({stroke: "#000000"});

        /*****************************
         *** DRAW HORIZONTAL LINES ***
         *****************************/

        var positionY = gutter + strokeWidth; //y-coordinate for current line

        for (var i = 0; i < numY; i++) {
            var attr = ( i == 0 || i == numY - 1 ) ? TWICE_STROKE_WIDTH : STROKE_WIDTH ;

            var path = Raphael.format("M{0} {2}L{1} {2}", gutter / 2, this.chartWidth + 1.5 * gutter, positionY);
            this.r.path(path).attr(attr);
            this.r.text(gutter / 2 - gutter / 4, positionY, this.ylabels[i]).attr({stroke: "#000000"});
            positionY += diffHeight * 2;
        }
		 
        /***************************
         *** DRAW VERTICAL LINES ***
         ***************************/

        var positionX = gutter + strokeWidth; //x-coordinate for current line

		// Draw main lines
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

        var buttonTypeSelect = document.getElementsByClassName('btn-type-select-audiogram');
        
    };
	
	// Plots AC_L - 'X'
	this.plotAC_L = function(x, y, f, h) {
		var r = 5 + Math.round(this.height/200); // drawing size
		
		var path = Raphael.format("M{0} {1}L{2} {3}M{4} {5}L{6} {7}", x - r, y - r, x + r, y + r, x - r, y + r, x + r, y - r);
		
		var tempPath = this.r.path(path).attr({
			"stroke-width": 2,
			"stroke-linecap": "round",
			"stroke-linejoin": "miter",
			'stroke': "#0000ff"
		});
		
		var point = {
			plotType: "AC_L",
			frequency: f,
			HL: h,
			cx: x,
			cy: y,
			pointPath: tempPath
		};
		
		this.AC_L.push(point);
	};
	
	// Plots AC_R - Circle
    this.plotAC_R = function (x, y, f, h) {
        var r = 5 + Math.round(this.height/200); // drawing size

        var tempPath = this.r.circle(x, y, r).attr({
            "stroke-width": 2,
            'stroke': "#ff0000"
        });

		var point = {
			plotType: "AC_R",
			frequency: f,
			HL: h,
			cx: x,
			cy: y,
			pointPath: tempPath
		};

        this.AC_R.push(point);
    };
	
	// Plots AC_NR_L - 'X' with arrow bottom-right
	this.plotAC_NR_L = function(x, y, f, h) {
		var r = 5 + Math.round(this.height/200); // drawing size
		
		var path = Raphael.format("M{0} {1}L{2} {3}M{4} {5}L{6} {7}L{8} {9}M{6} {7}L{10} {11}", x - r, y + r, x + r, y - r, x - r, y - r, x + r, y + r, x + r/2, y + r, x + r, y + r/2);
		
		var tempPath = this.r.path(path).attr({
			"stroke-width": 2,
			"stroke-linecap": "round",
			"stroke-linejoin": "miter",
			'stroke': "#0000ff"
		});
		
		var point = {
			plotType: "AC_R",
			frequency: f,
			HL: h,
			cx: x,
			cy: y,
			pointPath: tempPath
		};
		
		this.AC_NR_L.push(point);
	};
	
	// Plots the circle portion of AC_NR_R
	this.plotAC_NR_R1 = function(x, y, f, h) {
		var r = 5 + Math.round(this.height/200); // drawing size
		
		var tempPath = this.r.circle(x + r/3, y - r/3, (2 / 3) * r).attr({
			"stroke-width": 2,
			'stroke': "#ff0000"
		});
		
		var point = {
			plotType: "AC_NR_R",
			frequency: f,
			HL: h,
			cx: x,
			cy: y,
			pointPath: tempPath
		};
		
		this.AC_NR_R1.push(point);
	};
	
	// Plots the arrow portion of AC_NR_R
	this.plotAC_NR_R2 = function(x, y, f, h) {
		var r = 5 + Math.round(this.height/200); // drawing size
		
		var path = Raphael.format("M{0} {1}L{2} {3}L{4} {5}M{2} {3}L{6} {7}", x, y, x - r, y + r, x - r, y + r/2, x - r/2, y + r);
		
		var tempPath = this.r.path(path).attr({
			"stroke-width": 2,
			"stroke-linecap": "round",
			"stroke-linejoin": "miter",
			'stroke': "#ff0000"
		});
		
		var point = {
			plotType: "AC_NR_R",
			frequency: f,
			HL: h,
			cx: x,
			cy: y,
			pointPath: tempPath
		};
		
		this.AC_NR_R2.push(point);
	};

	// Plots AC_M_L - Square
	this.plotAC_M_L = function(x, y, f, h) {
		var r = 5 + Math.round(this.height/200); // drawing size
		
		var path = Raphael.format("M{0} {1}L{2} {3}L{4} {5}L{6} {7}L{0} {1}", x - r, y - r, x + r, y - r, x + r, y + r, x - r, y + r);
		
		var tempPath = this.r.path(path).attr({
			"stroke-width": 2,
			"stroke-linecap": "round",
			"stroke-linejoin": "miter",
			'stroke': "#0000ff"
		});
		
		var point = {
			plotType: "AC_M_L",
			frequency: f,
			HL: h,
			cx: x,
			cy: y,
			pointPath: tempPath
		};
		
		this.AC_M_L.push(point);
	};
	
	// Plots AC_M_R - Triangle
	this.plotAC_M_R = function(x, y, f, h) {
		var r = 5 + Math.round(this.height/200); // drawing size
		
		var path = Raphael.format("M{0} {1}L{2} {3}L{4} {5}L{0} {1}", x, y - r, x + r, y + r, x - r, y + r);
		
		var tempPath = this.r.path(path).attr({
			"stroke-width": 2,
			"stroke-linecap": "round",
			"stroke-linejoin": "miter",
			'stroke': "#ff0000"
		});
		
		var point = {
			plotType: "AC_M_R",
			frequency: f,
			HL: h,
			cx: x,
			cy: y,
			pointPath: tempPath
		};
		
		this.AC_M_R.push(point);
	};
	
	// Plots AC_M_NR_L - Square with arrow bottom right
	this.plotAC_M_NR_L = function(x, y, f, h) {
		var r = 5 + Math.round(this.height/200); // drawing size
		
		var path = Raphael.format("M{0} {1}L{2} {3}L{4} {5}L{6} {7}L{0} {1}L{8} {9}L{10} {11}M{8} {9}L{12} {13}", x + r/2, y + r/2, x - r, y + r/2, x - r, y - r, x + r/2, y - r, x + r, y + r, x + r/2, y + r, x + r, y + r/2);
		
		var tempPath = this.r.path(path).attr({
			"stroke-width": 2,
			"stroke-linecap": "round",
			"stroke-linejoin": "miter",
			'stroke': "#ff0000"
		});
		
		var point = {
			plotType: "AC_M_NR_L",
			frequency: f,
			HL: h,
			cx: x,
			cy: y,
			pointPath: tempPath
		};
		
		this.AC_M_NR_L.push(point);
	};
	
	// Plots AC_M_NR_R - Triangle with arrow bottom left
	this.plotAC_M_NR_R = function(x, y, f, h) {
		var r = 5 + Math.round(this.height/200); // drawing size
		
		var path = Raphael.format("M{0} {1}L{2} {3}L{4} {5}L{0} {1}L{6} {7}L{8} {9}M{6} {7}L{10} {11}", x - r/2, y + r/2, x + r/3, y - r, x + r, y + r/2, x - r, y + r, x - r, y + r/2, x - r/2, y + r);
		
		var tempPath = this.r.path(path).attr({
			"stroke-width": 2,
			"stroke-linecap": "round",
			"stroke-linejoin": "miter",
			'stroke': "#0000ff"
		});
		
		var point = {
			plotType: "AC_M_NR_R",
			frequency: f,
			HL: h,
			cx: x,
			cy: y,
			pointPath: tempPath
		};
		
		this.AC_M_NR_R.push(point);
	};
	
	// Plots BC_L - '>'
	this.plotBC_L = function(x, y, f, h) {
		var r = 5 + Math.round(this.height/200); // drawing size
		
		var path = Raphael.format("M{0} {1}L{2} {3}L{4} {5}", x - r + r, y - r, x + r + r, y, x - r + r, y + r);
		
		var tempPath = this.r.path(path).attr({
			"stroke-width": 2,
			"stroke-linecap": "round",
			"stroke-linejoin": "miter",
			'stroke': "#0000ff"
		});
		
		var point = {
			plotType: "BC_L",
			frequency: f,
			HL: h,
			cx: x,
			cy: y,
			pointPath: tempPath
		};
		
		this.BC_L.push(point);
	};
	
	// Plots BC_R - '<'
	this.plotBC_R = function(x, y, f, h) {
		var r = 5 + Math.round(this.height/200); // drawing size
		
		var path = Raphael.format("M{0} {1}L{2} {3}L{4} {5}", x + r - r, y - r, x - r - r, y, x + r - r, y + r);
		
		var tempPath = this.r.path(path).attr({
			"stroke-width": 2,
			"stroke-linecap": "round",
			"stroke-linejoin": "miter",
			'stroke': "#ff0000"
		});
		
		var point = {
			plotType: "BC_R",
			frequency: f,
			HL: h,
			cx: x,
			cy: y,
			pointPath: tempPath
		};
		
		this.BC_R.push(point);
	};
	
	// Plots BC_NR_L - '>' with arrow bottom right
	this.plotBC_NR_L = function(x, y, f, h) {
		var r = 5 + Math.round(this.height/200); // drawing size
		
		var path = Raphael.format("M{0} {1}L{2} {3}L{4} {5}L{6} {7}L{8} {9}M{6} {7}L{10} {11}", x - r + r, y - r, x + r, y - r/2, x - r + r, y, x + r, y + r, x - r/2 + r, y + r, x + r, y + r/2);
		
		var tempPath = this.r.path(path).attr({
			"stroke-width": 2,
			"stroke-linecap": "round",
			"stroke-linejoin": "miter",
			'stroke': "#0000ff"
		});
		
		var point = {
			plotType: "BC_NR_L",
			frequency: f,
			HL: h,
			cx: x,
			cy: y,
			pointPath: tempPath
		};
		
		this.BC_NR_L.push(point);
	};
	
	// Plots BC_NR_R - '<' with arrow bottom left
	this.plotBC_NR_R = function(x, y, f, h) {
		var r = 5 + Math.round(this.height/200); // drawing size
		
		var path = Raphael.format("M{0} {1}L{2} {3}L{4} {5}L{6} {7}L{8} {9}M{6} {7}L{10} {11}", x + r - r, y - r, x - r, y - r/2, x + r - r, y, x - r, y + r, x + r/2 - r, y + r, x - r, y + r/2);
		
		var tempPath = this.r.path(path).attr({
			"stroke-width": 2,
			"stroke-linecap": "round",
			"stroke-linejoin": "miter",
			'stroke': "#ff0000"
		});
		
		var point = {
			plotType: "BC_NR_R",
			frequency: f,
			HL: h,
			cx: x,
			cy: y,
			pointPath: tempPath
		};
		
		this.BC_NR_R.push(point);
	};
	
	// Plots BC_M_L - ']'
	this.plotBC_M_L = function(x, y, f, h) {
		var r = 5 + Math.round(this.height/200); // drawing size
		
		var path = Raphael.format("M{0} {1}L{2} {3}L{4} {5}L{6} {7}", x - r + r, y - r, x + r, y - r, x + r, y + r, x - r + r, y + r);
		
		var tempPath = this.r.path(path).attr({
			"stroke-width": 2,
			"stroke-linecap": "round",
			"stroke-linejoin": "miter",
			'stroke': "#0000ff"
		});
		
		var point = {
			plotType: "BC_M_L",
			frequency: f,
			HL: h,
			cx: x,
			cy: y,
			pointPath: tempPath
		};
		
		this.BC_M_L.push(point);
	};
	
	// Plots BC_M_R - '['
	this.plotBC_M_R = function(x, y, f, h) {
		var r = 5 + Math.round(this.height/200); // drawing size
		
		var path = Raphael.format("M{0} {1}L{2} {3}L{4} {5}L{6} {7}", x + r - r, y - r, x - r, y - r, x - r, y + r, x + r - r, y + r);
		
		var tempPath = this.r.path(path).attr({
			"stroke-width": 2,
			"stroke-linecap": "round",
			"stroke-linejoin": "miter",
			'stroke': "#ff0000"
		});
		
		var point = {
			plotType: "BC_M_R",
			frequency: f,
			HL: h,
			cx: x,
			cy: y,
			pointPath: tempPath
		};
		
		this.BC_M_R.push(point);
	};
	
	// Plots BC_M_NR_L - ']' with arrow bottom right
	this.plotBC_M_NR_L = function(x, y, f, h) {
		var r = 5 + Math.round(this.height/200); // drawing size
		
		var path = Raphael.format("M{0} {1}L{2} {3}L{4} {5}L{6} {7}M{4} {5}L{8} {9}L{10} {11}M{8} {9}L{12} {13}", x - r + r, y - r, x + r, y - r, x + r, y + r/2, x - r + r, y + r/2, x + r/2 + r, y + r, x + r, y + r, x + r/2 + r, y + r/2);
		
		var tempPath = this.r.path(path).attr({
			"stroke-width": 2,
			"stroke-linecap": "round",
			"stroke-linejoin": "miter",
			'stroke': "#0000ff"
		});
		
		var point = {
			plotType: "BC_M_NR_L",
			frequency: f,
			HL: h,
			cx: x,
			cy: y,
			pointPath: tempPath
		};
		
		this.BC_M_NR_L.push(point);
	};
	
	// Plots BC_M_NR_R - '[' with arrow bottom left
	this.plotBC_M_NR_R = function(x, y, f, h) {
		var r = 5 + Math.round(this.height/200); // drawing size
		
		var path = Raphael.format("M{0} {1}L{2} {3}L{4} {5}L{6} {7}M{4} {5}L{8} {9}L{10} {11}M{8} {9}L{12} {13}", x + r - r, y - r, x - r, y - r, x - r, y + r/2, x + r - r, y + r/2, x - r/2 - r, y + r, x - r, y + r, x - r/2 - r, y + r/2);
		
		var tempPath = this.r.path(path).attr({
			"stroke-width": 2,
			"stroke-linecap": "round",
			"stroke-linejoin": "miter",
			'stroke': "#ff0000"
		});
		
		var point = {
			plotType: "BC_M_NR_R",
			frequency: f,
			HL: h,
			cx: x,
			cy: y,
			pointPath: tempPath
		};
		
		this.BC_M_NR_R.push(point);
	};

	// Determines if the given point is within the gridlines
    this.onGrid = function (x, y) {
        var xGood = x >= this.gutter && x <= (this.width - this.gutter);    // is the x-coordinate within the plottable area?
        var yGood = y >= this.gutter && y <= (this.height - this.gutter);   // is the y-coordinate within the plottable area?
		
        return xGood && yGood;
    };

	
	// Determines the closest point on the grid to the clicked location
    this.closestPoint = function (x, y) {
        x = x - this.gutter;
        y = y - this.gutter;

        var positionX = Math.round(x / this.diffWidth);
        var positionY = Math.round(y / this.diffHeight);

        var f = this.frequencies[positionX];
        var h = this.ylabels[positionY];

        (positionX <= 4 && positionX % 2) && (positionX--); // if it falls in the first 4 and it's even, then

        x = Math.round(positionX * this.diffWidth + this.gutter + 1);
        y = Math.round(positionY * this.diffHeight + this.gutter + 1);

		this.plotType = $("input:radio[name=opt-select]:checked").val();

		// Selects which type of symbol to plot
		if (this.plotType == "AC_L") {
			this.clearPoints(f, this.AC_L);
			this.plotAC_L(x, y, f, h);
		} else if (this.plotType == "AC_R") {
			this.clearPoints(f, this.AC_R);
			this.plotAC_R(x, y, f, h);
		} else if (this.plotType == "AC_NR_L") {
			this.clearPoints(f, this.AC_NR_L);
			this.plotAC_NR_L(x, y, f, h);
		} else if (this.plotType == "AC_NR_R") {
			this.clearPoints(f, this.AC_NR_R1);
			this.clearPoints(f, this.AC_NR_R2);
			this.plotAC_NR_R1(x, y, f, h);
			this.plotAC_NR_R2(x, y, f, h);
		} else if (this.plotType == "AC_M_L") {
			this.clearPoints(f, this.AC_M_L);
			this.plotAC_M_L(x, y, f, h);
		} else if (this.plotType == "AC_M_R") {
			this.clearPoints(f, this.AC_M_R);
			this.plotAC_M_R(x, y, f, h);
		} else if (this.plotType == "AC_M_NR_L") {
			this.clearPoints(f, this.AC_M_NR_L);
			this.plotAC_M_NR_L(x, y, f, h);
		} else if (this.plotType == "AC_M_NR_R") {
			this.clearPoints(f, this.AC_M_NR_R);
			this.plotAC_M_NR_R(x, y, f, h);
		} else if (this.plotType == "BC_L") {
			this.clearPoints(f, this.BC_L);
			this.plotBC_L(x, y, f, h);
		} else if (this.plotType == "BC_R") {
			this.clearPoints(f, this.BC_R);
			this.plotBC_R(x, y, f, h);
		} else if (this.plotType == "BC_NR_L") {
			this.clearPoints(f, this.BC_NR_L);
			this.plotBC_NR_L(x, y, f, h);
		} else if (this.plotType == "BC_NR_R") {
			this.clearPoints(f, this.BC_NR_R);
			this.plotBC_NR_R(x, y, f, h);
		} else if (this.plotType == "BC_M_L") {
			this.clearPoints(f, this.BC_M_L);
			this.plotBC_M_L(x, y, f, h);
		} else if (this.plotType == "BC_M_R") {
			this.clearPoints(f, this.BC_M_R);
			this.plotBC_M_R(x, y, f, h);
		} else if (this.plotType == "BC_M_NR_L") {
			this.clearPoints(f, this.BC_M_NR_L);
			this.plotBC_M_NR_L(x, y, f, h);
		} else if (this.plotType == "BC_M_NR_R") {
			this.clearPoints(f, this.BC_M_NR_R);
			this.plotBC_M_NR_R(x, y, f, h);
		} else {
			console.log("Error: Invalid plotType \"" + this.plotType + "\"");
		}
    };
	
	this.clearPoints = function(frequency, array)
	{	
		console.log(array);
		
		for (i = 0; i < array.length; i++)
		{		
			if (array[i].frequency == frequency)
			{
				array[i].pointPath.remove();
				array.splice(i, 1);
			}
		}
	};

	// Handles events
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
	
	// Calls the individual functions of the audiogram to draw it and set up event listeners
    this.initialize = function (id, size) {
        this.id = id;
        this.el = document.getElementById(id);
        
        this.draw(size);
        
        this.svg = this.el.querySelector("svg");

        this.svg.addEventListener("click", this, false);
        this.svg.addEventListener("mousedown", this, false);
        this.svg.addEventListener("mouseup", this, false);

        return this;
    };
}