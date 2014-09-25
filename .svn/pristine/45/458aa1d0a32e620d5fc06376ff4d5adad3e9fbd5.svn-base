/**
 * Controls an HTML input of type range
 * @constructor
 * @param {String} id - the DOM id of the HTML input element
 */

function RangeInput(id) {
    this.el = document.getElementById(id);
    this.val = this.el.value;
    this.handlerFunction;
    this.handerObj;

    /**
     * Determines the change of the range input element's value
     * Stores the current value so it can be compared with the next new value
     *
     * @param {EventObject} event - event object fired by event listener
     */

    this.handleEvent = function (event) {
        if (event.type !== "change") {
            return;
        };
        var change = parseInt(this.el.value, 10) - parseInt(this.val, 10);
        this.handlerFunction.call(this.handlerObj, change);
        this.val = this.el.value; //store the current value
    };

    /**
     * Returns the current value of the range input element
     *
     * @returns {Number} value - current value of the range input
     */

    this.getValue = function () {
        return parseInt(this.val);
    };

    /**
     * Registers an event handler function for the "onchange" event
     * Calls the event handler with the value of the range's change
     *
     * @param {Object} obj = "this" scope to call the function with
     * @param {Function} handler = event handler to be called when the range's value changes
     */

    this.subscribe = function (obj, handler) {
        this.handlerFunction = handler;
        this.handlerObj = obj;
        this.el.addEventListener("change", this, false);
    };

    return this; //return "this" object so that we can chain function calls
}

/**
 * Creates a decibel chart
 * @constructor
 * @param {String} id - the DOM id of the HTML input element
 * @param {Number} width - the width of the chart in pixels
 * @param {Number} id - the height of the chart in pixels
 */

function DecibelChart(id, width, height) {
    this.gutter;
    this.width = width;
    this.height = height;
    this.paper = Raphael(id, width + 2, height + 2);
    this.dB;
    this.meter;
    this.input;

    /**
     * Draws the initital background of the chart
     */

    this.initialize = function () {
        this.paper.rect(1, 1, this.width, this.height, 0).attr({
            "fill": "white"
        });
    };

    /**
     * Draws the meter of the chart at the current decibel level
     */

    //    this.drawMeter = function () {
    //        this.meter && this.meter.remove(); //shortcut if statement
    //
    //        var path = Raphael.format("M{0} 1L{0} {1}", this.dB + 1, this.height);
    //        this.meter = this.paper.path(path).attr({
    //            "stroke": "#000000",
    //            "stroke-width": 1
    //        });
    //    };

    /**
     * Increments this.dB by dB_change and then calls this.drawMeter to redraw meter
     *
     * @param {Number} dB_change - the decibel value change
     */

    this.incrementDecibels = function (dB_change) {
        this.dB = this.dB + dB_change;
        this.drawMeter();
    };

    /**
     * Connects the Input Object to the chart
     *
     * @param {Input} input - the input object wrapping the DOM element
     */

    this.registerInput = function (input) {
        this.input = input.subscribe(this, this.incrementDecibels);
        this.dB = input.getValue();
    }

    this.initialize();
    return this; //return "this" object so that we can chain function calls
}