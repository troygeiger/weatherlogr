(
    function ($) {
        /** @param {any} options */
        $.fn.lookup = function (options) {


            if (this.length == 0 || this.length > 1) {
                throw "lookup plugin: There can only be one element selected!";
            }
            if (options === "instance") {
                return this[0].lookup;
            }
            if (options && typeof options != "object") {
                throw "lookup plugin: options must be an object!";
            }
            if (!this.is("input")) {
                throw "lookup plugin: Selected type must be of type input.";
            }


            options = $.extend({
                visible: false,
                maxVisible: 10,
                data: {
                    displayValue: undefined,
                    url: undefined,
                    maxResults: undefined
                },
                onSelectionChanged: undefined
            }, options);
            
            var factory = {
                keyCodes: {
                    up: 38,
                    down: 40,
                    enter: 13
                },
                data: [],
                /** @type {JQuery} */
                owner: $(this),
                /** @type {JQuery} */
                popup: null,
                /**@type {JQuery} */
                selectedItem: undefined,

                _init: function () {

                    /** @type {JQuery} */
                    this.popup = $("<select>").addClass("lookup-popup");
                    if (!options.visible) this.popup.hide();
                    this.owner.parent().append(this.popup);
                    this.owner.on("input", this._onOwnerChange);
                    this.owner.on("resize", factory._refresh);
                    this.owner.on("blur", function () {
                        //if (!$(document.activeElement).hasClass("lookup-item"))
                        //    factory._setVisibility(false);
                        console.log(factory.popup[0].hasFocus)
                    });
                    this.owner.on("focus", factory._doLookup);

                    this.owner.on("keydown", function (e) {
                        switch (e.which) {
                            case factory.keyCodes.up:
                            case factory.keyCodes.down:
                                e.preventDefault();
                                factory._updateHighlighted(e.which);
                                break;
                            case factory.keyCodes.enter:
                                if (factory._selectHighlighted()) {
                                    e.preventDefault();
                                }
                                break;
                            default:
                                break;
                        }
                    });

                    this.popup.on("mousemove", factory._clearHighlighted);

                    this._refresh();
                    this.owner.setOption = factory._setOption;
                    this.owner.getSelected = factory._getSelected;
                },
                _setOption: function (option, value) {
                    if (option) {
                        options[option] = value;
                        factory._validateOptions();
                        factory._refresh();
                    }
                },
                _validateOptions: function(){
                    if (options.maxVisible <= 1)
                        options.maxVisible = 2;
                },
                _refresh: function () {

                    var mePos = this.owner.position();
                    var meSize = {
                        width: this.owner.outerWidth(),
                        height: this.owner.outerHeight()
                    };
                    this.popup.css("top", mePos.top + meSize.height + 2);
                    this.popup.css("width", meSize.width);
                    this.popup.css("height", "auto");
                },
                _setVisibility: function (visible) {
                    if (visible == options.visible) return;
                    if (visible) factory.popup.fadeIn();
                    if (!visible) factory.popup.fadeOut();
                    options.visible = visible;
                },
                _doLookup: function () {
                    if (!options.data.url) return;
                    var value = factory.owner.val();
                    factory.data = undefined;
                    if (!value || factory.selectedItem) return;
                    var data = { query: value };
                    if (options.data.maxResults)
                        data.maxResults = options.data.maxResults;
                    $.getJSON(options.data.url, data, function (data) {
                        factory.data = data;
                        factory._populateResults();
                    });
                },
                _populateResults: function () {
                    factory.popup.html("");
                    factory.data.forEach(element => {
                        factory.popup.append(
                            $("<option>")
                                .html(element[options.data.displayValue])
                                .addClass("lookup-item")
                                .data(element)
                                .on("click", function () {
                                    factory._setSelected($(this).data());
                                })
                        );
                    });
                    factory.popup.attr({
                        size: factory.data.length > options.maxVisible ? options.maxVisible :
                            factory.data.length <= 1 ? 2 : factory.data.length
                    });
                    factory._setVisibility(true);
                },
                _onOwnerChange: function () {
                    factory._setVisibility(false);
                    if (factory.selectedItem)
                        factory._setSelected(undefined);
                    if (factory.wait) window.clearTimeout(factory.wait);
                    factory.wait = window.setTimeout(factory._doLookup, 300);
                },
                _getSelected: function () {
                    return factory.selectedItem;
                },
                _setSelected: function (item) {
                    factory.selectedItem = item;
                    factory._setVisibility(false);
                    if (item)
                        factory.owner.val(item[options.data.displayValue]);
                    if (typeof options.onSelectionChanged === "function") {
                        options.onSelectionChanged(item);
                    }
                },
                _updateHighlighted: function (key) {
                    if (!factory.data.length) return;
                    var items = factory.popup.find(".lookup-item");
                    var cur = -1;
                    for (var i = 0; i < items.length; i++) {
                        if ($(items[i]).hasClass("lookup-item-highlight")) {
                            cur = i;
                            break;
                        }
                    }

                    cur = key == factory.keyCodes.up ? cur - 1 : cur + 1;
                    if (cur == -2) cur = items.length - 1;
                    if (cur >= items.length) cur = 0;
                    items.removeClass("lookup-item-highlight");

                    if (cur > -1 && cur < items.length) {
                        $(items[cur]).addClass("lookup-item-highlight");
                        items[cur].scrollIntoView();
                    }
                },
                _clearHighlighted: function () {
                    factory.popup.find(".lookup-item-highlight").removeClass("lookup-item-highlight");
                },
                _selectHighlighted: function () {
                    if (!options.visible) return factory;
                    var item = factory.popup.find(".lookup-item-highlight");
                    if (item.length) {
                        factory._setSelected(item.data());
                        return true;
                    }
                    return false;
                }
            };
            factory._validateOptions();
            factory._init();
            
            // Store instance
            this[0].lookup = this;
            return this;
        };
    })(jQuery);