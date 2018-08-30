/*
 *
 *   Z2DATA - Responsive Admin Theme
 *   By: Mostafa Yahia - Stylaat@outlook.com
 *
 */

$(function () {
  $('[data-toggle="tooltip"]').tooltip()
})

$(document).ready(function () {


    // Add body-small class if window less than 768px
    if ($(this).width() < 769) {
        $('body').addClass('body-small')
    } else {
        $('body').removeClass('body-small')
    }

    // MetsiMenu
    $('#side-menu').metisMenu();

    // Collapse ibox function
    $('.collapse-link').click(function () {
        var ibox = $(this).closest('div.ibox');
        var button = $(this).find('i');
        var content = ibox.find('div.ibox-content');
        content.slideToggle(200);
        button.toggleClass('fa-chevron-up').toggleClass('fa-chevron-down');
        ibox.toggleClass('').toggleClass('border-bottom');
        setTimeout(function () {
            ibox.resize();
            ibox.find('[id^=map-]').resize();
        }, 50);
    });

    // Close ibox function
    $('.close-link').click(function () {
        var content = $(this).closest('div.ibox');
        content.remove();
    });

    // Fullscreen ibox function
    $('.fullscreen-link').click(function () {
        var ibox = $(this).closest('div.ibox');
        var button = $(this).find('i');
        $('body').toggleClass('fullscreen-ibox-mode');
        button.toggleClass('fa-expand').toggleClass('fa-compress');
        ibox.toggleClass('fullscreen');
        setTimeout(function () {
            $(window).trigger('resize');
        }, 100);
    });

    // Close menu in canvas mode
    $('.close-canvas-menu').click(function () {
        $("body").toggleClass("mini-navbar");
        SmoothlyMenu();
    });

    // Run menu of canvas
    $('body.canvas-menu .sidebar-collapse').slimScroll({
        height: '100%',
        railOpacity: 0.9
    });

    // Open close right sidebar
    $('.right-sidebar-toggle').click(function () {
        $('#right-sidebar').toggleClass('sidebar-open');
    });

    // Initialize slimscroll for right sidebar
    $('.sidebar-container').slimScroll({
        height: '100%',
        railOpacity: 0.4,
        wheelStep: 10
    });

    // Open close small chat
    $('.open-small-chat').click(function () {
        $(this).children().toggleClass('fa-comments').toggleClass('fa-remove');
        $('.small-chat-box').toggleClass('active');
    });

    // Initialize slimscroll for small chat
    $('.small-chat-box .content').slimScroll({
        height: '234px',
        railOpacity: 0.4
    });

    // Small todo handler
    $('.check-link').click(function () {
        var button = $(this).find('i');
        var label = $(this).next('span');
        button.toggleClass('fa-check-square').toggleClass('fa-square-o');
        label.toggleClass('todo-completed');
        return false;
    });

    // Append config box / Only for demo purpose
    // Uncomment on server mode to enable XHR calls
    //$.get("skin-config.html", function (data) {
    //    if (!$('body').hasClass('no-skin-config'))
    //        $('body').append(data);
    //});

    // Minimalize menu
    $('.navbar-minimalize').click(function () {
        $("body").toggleClass("mini-navbar");
        SmoothlyMenu();

    });

    // Tooltips demo
    $('.tooltip-demo').tooltip({
        selector: "[data-toggle=tooltip]",
        container: "body"
    });

    // Move modal to body
    // Fix Bootstrap backdrop issu with animation.css
    $('.modal').appendTo("body");


    $("[data-toggle=popover]")
        .popover();

    // Add slimscroll to element
    $('.full-height-scroll').slimscroll({
        height: '100%'
    })
});


// check if browser support HTML5 local storage
function localStorageSupport() {
    return (('localStorage' in window) && window['localStorage'] !== null)
}

// For demo purpose - animation css script
function animationHover(element, animation) {
    element = $(element);
    element.hover(
        function () {
            element.addClass('animated ' + animation);
        },
        function () {
            //wait for animation to finish before removing classes
            window.setTimeout(function () {
                element.removeClass('animated ' + animation);
            }, 2000);
        });
}

function SmoothlyMenu() {
    if (!$('body').hasClass('mini-navbar') || $('body').hasClass('body-small')) {
        // Hide menu in order to smoothly turn on when maximize menu
        $('#side-menu').hide();
        // For smoothly turn on menu
        setTimeout(
            function () {
                $('#side-menu').fadeIn(400);
            }, 200);
    } else if ($('body').hasClass('fixed-sidebar')) {
        $('#side-menu').hide();
        setTimeout(
            function () {
                $('#side-menu').fadeIn(400);
            }, 100);
    } else {
        // Remove all inline style from jquery fadeIn function to reset menu state
        $('#side-menu').removeAttr('style');
    }
}

// Dragable panels
function WinMove() {
    var element = "[class*=col]";
    var handle = ".ibox-title";
    var connect = "[class*=col]";
    $(element).sortable(
        {
            handle: handle,
            connectWith: connect,
            tolerance: 'pointer',
            forcePlaceholderSize: true,
            opacity: 0.8
        })
        .disableSelection();
}




/////////////// #Data Tables ////////////////////

    $(document).ready(function(){
        $('.dataTables-example').DataTable({
            dom: '<"html5buttons"B>lTfgitp',
            buttons: [
                { extend: 'copy'},
                {extend: 'csv'},
                {extend: 'excel', title: 'ExampleFile'},
                {extend: 'pdf', title: 'ExampleFile'},

                {extend: 'print',
                 customize: function (win){
                        $(win.document.body).addClass('white-bg');
                        $(win.document.body).css('font-size', '10px');

                        $(win.document.body).find('table')
                                .addClass('compact')
                                .css('font-size', 'inherit');
                }
                }
            ]

        });
    });

    function fnClickAddRow() {
        $('#editable').dataTable().fnAddData( [
            "Custom row",
            "New row",
            "New row",
            "New row",
            "New row" ] );

    }

/////////////// #tab-resize ////////////////////
    //dispatch event resize to trigger graph re-render
    $('a[data-toggle=tab').on('shown.bs.tab', function (e) {
      window.dispatchEvent(new Event('resize'));   
    });

/////////////// #F O R M S ////////////////////
    $(document).ready(function(){

            $(".select2_demo_1").select2();
            $(".select2_demo_2").select2();
            $(".select2_demo_3").select2({
                placeholder: "Select a state",
                allowClear: true
            });

            var $image = $(".image-crop > img")
            $($image).cropper({
                aspectRatio: 1.618,
                preview: ".img-preview",
                done: function(data) {
                    // Output the result data for cropping image.
                }
            });

            var $inputImage = $("#inputImage");
            if (window.FileReader) {
                $inputImage.change(function() {
                    var fileReader = new FileReader(),
                            files = this.files,
                            file;

                    if (!files.length) {
                        return;
                    }

                    file = files[0];

                    if (/^image\/\w+$/.test(file.type)) {
                        fileReader.readAsDataURL(file);
                        fileReader.onload = function () {
                            $inputImage.val("");
                            $image.cropper("reset", true).cropper("replace", this.result);
                        };
                    } else {
                        showMessage("Please choose an image file.");
                    }
                });
            } else {
                $inputImage.addClass("hide");
            }

            $("#download").click(function() {
                window.open($image.cropper("getDataURL"));
            });

            $("#zoomIn").click(function() {
                $image.cropper("zoom", 0.1);
            });

            $("#zoomOut").click(function() {
                $image.cropper("zoom", -0.1);
            });

            $("#rotateLeft").click(function() {
                $image.cropper("rotate", 45);
            });

            $("#rotateRight").click(function() {
                $image.cropper("rotate", -45);
            });

            $("#setDrag").click(function() {
                $image.cropper("setDragMode", "crop");
            });

            $('#data_1 .input-group.date').datepicker({
                todayBtn: "linked",
                keyboardNavigation: false,
                forceParse: false,
                calendarWeeks: true,
                autoclose: true
            });

            $('#data_2 .input-group.date').datepicker({
                startView: 1,
                todayBtn: "linked",
                keyboardNavigation: false,
                forceParse: false,
                autoclose: true,
                format: "dd/mm/yyyy"
            });

            $('#data_3 .input-group.date').datepicker({
                startView: 2,
                todayBtn: "linked",
                keyboardNavigation: false,
                forceParse: false,
                autoclose: true
            });

            $('#data_4 .input-group.date').datepicker({
                minViewMode: 1,
                keyboardNavigation: false,
                forceParse: false,
                autoclose: true,
                todayHighlight: true
            });

            $('#data_5 .input-daterange').datepicker({
                keyboardNavigation: false,
                forceParse: false,
                autoclose: true
            });

            var elem = document.querySelector('.js-switch');
            var switchery = new Switchery(elem, { color: '#1AB394' });

            var elem_2 = document.querySelector('.js-switch_2');
            var switchery_2 = new Switchery(elem_2, { color: '#ED5565' });

            var elem_3 = document.querySelector('.js-switch_3');
            var switchery_3 = new Switchery(elem_3, { color: '#1AB394' });

            $('.i-checks').iCheck({
                checkboxClass: 'icheckbox_square-green',
                radioClass: 'iradio_square-green'
            });

            $('.demo1').colorpicker();

            var divStyle = $('.back-change')[0].style;
            $('#demo_apidemo').colorpicker({
                color: divStyle.backgroundColor
            }).on('changeColor', function(ev) {
                        divStyle.backgroundColor = ev.color.toHex();
                    });

            $('.clockpicker').clockpicker();

            $('input[name="daterange"]').daterangepicker();

            $('#reportrange span').html(moment().subtract(29, 'days').format('MMMM D, YYYY') + ' - ' + moment().format('MMMM D, YYYY'));

            $('#reportrange').daterangepicker({
                format: 'MM/DD/YYYY',
                startDate: moment().subtract(29, 'days'),
                endDate: moment(),
                minDate: '01/01/2012',
                maxDate: '12/31/2015',
                dateLimit: { days: 60 },
                showDropdowns: true,
                showWeekNumbers: true,
                timePicker: false,
                timePickerIncrement: 1,
                timePicker12Hour: true,
                ranges: {
                    'Today': [moment(), moment()],
                    'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
                    'Last 7 Days': [moment().subtract(6, 'days'), moment()],
                    'Last 30 Days': [moment().subtract(29, 'days'), moment()],
                    'This Month': [moment().startOf('month'), moment().endOf('month')],
                    'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
                },
                opens: 'right',
                drops: 'down',
                buttonClasses: ['btn', 'btn-sm'],
                applyClass: 'btn-primary',
                cancelClass: 'btn-default',
                separator: ' to ',
                locale: {
                    applyLabel: 'Submit',
                    cancelLabel: 'Cancel',
                    fromLabel: 'From',
                    toLabel: 'To',
                    customRangeLabel: 'Custom',
                    daysOfWeek: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr','Sa'],
                    monthNames: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
                    firstDay: 1
                }
            }, function(start, end, label) {
                console.log(start.toISOString(), end.toISOString(), label);
                $('#reportrange span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
            });

            


            $(".touchspin1").TouchSpin({
                buttondown_class: 'btn btn-white',
                buttonup_class: 'btn btn-white'
            });

            $(".touchspin2").TouchSpin({
                min: 0,
                max: 100,
                step: 0.1,
                decimals: 2,
                boostat: 5,
                maxboostedstep: 10,
                postfix: '%',
                buttondown_class: 'btn btn-white',
                buttonup_class: 'btn btn-white'
            });

            $(".touchspin3").TouchSpin({
                verticalbuttons: true,
                buttondown_class: 'btn btn-white',
                buttonup_class: 'btn btn-white'
            });


    });
    

/////////////// #Typehead ////////////////////

    $(document).ready(function(){

        $('.typeahead_1').typeahead({
            source: ["item 1","item 2","item 3"]
        });


    });

////////

/////////////// #chart-donut-Overview ////////////////////

        $(document).ready(function () {
         c3.generate({
            bindto: '#chart',
            data: {
                columns: [
                    ['data1', 125.2],
                    ['data2', 282.7],
                    ['data6', 329.7]
                ],
                type: 'donut',
                order: null
            },
            donut: {
                label: {
              },
              title: "Products statistics"
            }
          });

/////////////// #chart-donut-Products ////////////////////
        var chart = c3.generate({
            data: {
                columns: [
                    ['Lulu', 50],
                    ['Olaf', 30],
                    ['Olaf', 20],
                ],
                type : 'donut'
            },
            donut: {
                label: {
              },
              title: "Products statistics"
            },
            bindto: '#chartproducts'
          });

/////////////// #chart-donut-Products ////////////////////
        var chart = c3.generate({
            data: {
                columns: [
                    ['Long term debt', 50],
                    ['Short term debt', 30],
                ],
                type : 'donut'
            },
            donut: {
                label: {
              },
              title: "Total Debt(MRQ) M "
            },
            bindto: '#charttotaldebt'
          });

/////////////// #chart-donut-Products ////////////////////
        var chart = c3.generate({
            data: {
                columns: [
                    ['Computing and Graphics', 45],
                    ['Enterprise, Embedded and Semi-Custom', 55],
                ],
                type : 'donut'
            },
            donut: {
                label: {
              },
              title: "Business Segmentation"
            },
            bindto: '#chartbusinesssegmentation'
          });

/////////////// #chart-donut-Products-SideBar ////////////////////
        var donut = c3.generate({
            data: {
                columns: [
                    ['Lulu', 20],
                    ['Olaf', 70],
                    ['Olaf', 10],
                ],
                type : 'donut'
            },
            donut: {
                label: {
              },
              title: "Products statistics"
            },
            bindto: '#revenuebyproduct'
          });

        });

/////////////// #flot-line-chart-moving ////////////////////
    $(function() {

        var container = $("#flot-line-chart-moving");

        // Determine how many data points to keep based on the placeholder's initial size;
        // this gives us a nice high-res plot while avoiding more than one point per pixel.

        var maximum = container.outerWidth() / 2 || 300;

        //

        var data = [];

        function getRandomData() {

            if (data.length) {
                data = data.slice(1);
            }

            while (data.length < maximum) {
                var previous = data.length ? data[data.length - 1] : 50;
                var y = previous + Math.random() * 10 - 5;
                data.push(y < 0 ? 0 : y > 100 ? 100 : y);
            }

            // zip the generated y values with the x values

            var res = [];
            for (var i = 0; i < data.length; ++i) {
                res.push([i, data[i]])
            }

            return res;
        }

        series = [{
            data: getRandomData(),
            lines: {
                fill: true
            }
        }];


        var plot = $.plot(container, series, {
            grid: {

                color: "#999999",
                tickColor: "#fff",
                borderWidth:0,
                minBorderMargin: 20,
                labelMargin: 10,
                backgroundColor: {
                    colors: ["#ffffff", "#ffffff"]
                },
                margin: {
                    top: 8,
                    bottom: 20,
                    left: 20
                },
                markings: function(axes) {
                    var markings = [];
                    var xaxis = axes.xaxis;
                    for (var x = Math.floor(xaxis.min); x < xaxis.max; x += xaxis.tickSize * 2) {
                        markings.push({
                            xaxis: {
                                from: x,
                                to: x + xaxis.tickSize
                            },
                            color: "#fff"
                        });
                    }
                    return markings;
                }
            },
            colors: ["#04be77"],
            xaxis: {
                tickFormatter: function() {
                    return "";
                }
            },
            yaxis: {
                min: 0,
                max: 110
            },
            legend: {
                show: true
            }
        });

        // Update the random dataset at 25FPS for a smoothly-animating chart

        setInterval(function updateRandom() {
            series[0].data = getRandomData();
            plot.setData(series);
            plot.draw();
        }, 40);

    });

/////////////// #flot-bar-chart-Overall-company-score ////////////////////
    (function ($) {
      var options = {
          series: {
              valueLabels: {
                  show:            false,
                  showAsHtml:      false, // Set to true if you wanna switch back to DIV usage (you need plot.css for this)
                  showLastValue:   false, // Use this to show the label only for the last value in the series
                  labelFormatter:  function(v) { return v; }, // Format the label value to what you want
                  align:           'start', // can also be 'center', 'left' or 'right'
                  plotAxis:        'y', // Set to the axis values you wish to plot
                  hideZero:        false
              }
          }
      };

      function init(plot) {
        plot.hooks.draw.push( function (plot, ctx) {


          $.each(plot.getData(), function(ii, series) {
            if (!series.valueLabels.show) return;

            var showLastValue  = series.valueLabels.showLastValue;
            var showAsHtml     = series.valueLabels.showAsHtml;
            var plotAxis       = series.valueLabels.plotAxis;
            var labelFormatter = series.valueLabels.labelFormatter;
            var fontcolor      = series.valueLabels.fontcolor;
            var xoffset        = series.valueLabels.xoffset;
            var yoffset        = series.valueLabels.yoffset;
            var align          = series.valueLabels.align;
            var font           = series.valueLabels.font;
            var hideZero       = series.valueLabels.hideZero;
            // Workaround, since Flot doesn't set this value anymore
            series.seriesIndex = ii;

            if (showAsHtml) {
              plot.getPlaceholder().find("#valueLabels"+ii).remove();
            }

            var html       = '<div id="valueLabels' + series.seriesIndex + '" class="valueLabels">';
            var last_val   = null;
            var last_x     = -1000;
            var last_y     = -1000;
            var categories = series.xaxis.options.mode == 'categories';

            for (var i = 0; i < series.data.length; ++i) {

              if (series.data[i] === null || (showLastValue && i != series.data.length-1))  continue;

              var x = series.data[i][0], y = series.data[i][1];

              if (categories) {
                x = series.xaxis.categories[x];
              }

              if (x < series.xaxis.min || x > series.xaxis.max || y < series.yaxis.min || y > series.yaxis.max)  continue;

              var val = ( plotAxis === 'x' ) ? x : y;

          if(val == null){val=''}
          
              if ( val === 0 && hideZero ) continue;

              if (series.valueLabels.valueLabelFunc) {
                val = series.valueLabels.valueLabelFunc({ series: series, seriesIndex: ii, index: i });
              }

              val = "" + val;
              val = labelFormatter(val);

              if (val != last_val || i == series.data.length - 1) {
                var xx = series.xaxis.p2c(x) + plot.getPlotOffset().left;
                var yy = series.yaxis.p2c(y) - 12 + plot.getPlotOffset().top;

                if ( Math.abs(yy - last_y) > 20 || last_x < xx) {
                  last_val = val;
                  last_x = xx + val.length * 8;
                  last_y = yy;
                  if (!showAsHtml) {
                    // Little 5 px padding here helps the number to get
                    // closer to points
                    x_pos = xx;
                    y_pos = yy + 6;

                    // If the value is on the top of the canvas, we need
                    // to push it down a little
                    if (yy <= 0) y_pos = 18;

                    // The same happens with the x axis
                    if (xx >= plot.width()) {
                      x_pos = plot.width();
                    }

                    if (font) {
                      ctx.font = font;
                    }
            if(typeof(fontcolor) != 'undefined'){
                      ctx.fillStyle     = fontcolor;
            }
                    ctx.shadowOffsetX = 0;
                    ctx.shadowOffsetY = 0;
                    ctx.shadowBlur    = 1.5;
            if(typeof(fontcolor) != 'undefined'){
                      ctx.shadowColor   = fontcolor;
            }
                    ctx.textAlign     = align;

                    ctx.fillText(val, x_pos, y_pos);
                  }
                  else {
                    var head = '<div style="left:' + xx + 'px;top:' + yy + 'px;" class="valueLabel';
                    var tail = '">' + val + '</div>';
                    html += head + "Light" + tail + head + tail;
                  }
                }
              }
            }
            if (showAsHtml) {
              html += "</div>";
              plot.getPlaceholder().append(html);
            }
          });
        });
      }

      $.plot.plugins.push({
        init: init,
        options: options,
        name: 'valueLabels',
        version: '1.2'
      });
    })(jQuery);

    (function ($) {
        var options = {
            xaxis: {
                categories: null
            },
            yaxis: {
                categories: null
            }
        };
        
        function processRawData(plot, series, data, datapoints) {
            // if categories are enabled, we need to disable
            // auto-transformation to numbers so the strings are intact
            // for later processing

            var xCategories = series.xaxis.options.mode == "categories",
                yCategories = series.yaxis.options.mode == "categories";
            
            if (!(xCategories || yCategories))
                return;

            var format = datapoints.format;

            if (!format) {
                // FIXME: auto-detection should really not be defined here
                var s = series;
                format = [];
                format.push({ x: true, number: true, required: true });
                format.push({ y: true, number: true, required: true });

                if (s.bars.show || (s.lines.show && s.lines.fill)) {
                    var autoscale = !!((s.bars.show && s.bars.zero) || (s.lines.show && s.lines.zero));
                    format.push({ y: true, number: true, required: false, defaultValue: 0, autoscale: autoscale });
                    if (s.bars.horizontal) {
                        delete format[format.length - 1].y;
                        format[format.length - 1].x = true;
                    }
                }
                
                datapoints.format = format;
            }

            for (var m = 0; m < format.length; ++m) {
                if (format[m].x && xCategories)
                    format[m].number = false;
                
                if (format[m].y && yCategories)
                    format[m].number = false;
            }
        }

        function getNextIndex(categories) {
            var index = -1;
            
            for (var v in categories)
                if (categories[v] > index)
                    index = categories[v];

            return index + 1;
        }

        function categoriesTickGenerator(axis) {
            var res = [];
            for (var label in axis.categories) {
                var v = axis.categories[label];
                if (v >= axis.min && v <= axis.max)
                    res.push([v, label]);
            }

            res.sort(function (a, b) { return a[0] - b[0]; });

            return res;
        }
        
        function setupCategoriesForAxis(series, axis, datapoints) {
            if (series[axis].options.mode != "categories")
                return;
            
            if (!series[axis].categories) {
                // parse options
                var c = {}, o = series[axis].options.categories || {};
                if ($.isArray(o)) {
                    for (var i = 0; i < o.length; ++i)
                        c[o[i]] = i;
                }
                else {
                    for (var v in o)
                        c[v] = o[v];
                }
                
                series[axis].categories = c;
            }

            // fix ticks
            if (!series[axis].options.ticks)
                series[axis].options.ticks = categoriesTickGenerator;

            transformPointsOnAxis(datapoints, axis, series[axis].categories);
        }
        
        function transformPointsOnAxis(datapoints, axis, categories) {
            // go through the points, transforming them
            var points = datapoints.points,
                ps = datapoints.pointsize,
                format = datapoints.format,
                formatColumn = axis.charAt(0),
                index = getNextIndex(categories);

            for (var i = 0; i < points.length; i += ps) {
                if (points[i] == null)
                    continue;
                
                for (var m = 0; m < ps; ++m) {
                    var val = points[i + m];

                    if (val == null || !format[m][formatColumn])
                        continue;

                    if (!(val in categories)) {
                        categories[val] = index;
                        ++index;
                    }
                    
                    points[i + m] = categories[val];
                }
            }
        }

        function processDatapoints(plot, series, datapoints) {
            setupCategoriesForAxis(series, "xaxis", datapoints);
            setupCategoriesForAxis(series, "yaxis", datapoints);
        }

        function init(plot) {
            plot.hooks.processRawData.push(processRawData);
            plot.hooks.processDatapoints.push(processDatapoints);
        }
        
        $.plot.plugins.push({
            init: init,
            options: options,
            name: 'categories',
            version: '1.0'
        });
    })(jQuery);

    $(document).ready(function(){
        var data =  [
            {color: '#499a08', data: [["5 Years", 80]]},
            {color: '#499a08', data: [["1 Years", 80]]},
            {color: '#499a08', data: [["6 months", 75]]},
            {color: '#fbcc33', data: [["3 months", 65]]},
            {color: '#fbcc33', data: [["Current", 65]]}
        ];

        
        $.plot("#flot-bar-chart", data, {
                series: {
                    // grow: {
                    //  active: true,
                    //  stepMode: "maximum"
                    // },
                    bars: {
                        show: true,
                        align: "center",
                        barWidth: 0.55,
                        fill: 1     
                    },
                    valueLabels: {
                        show: true,
                        showAsHtml: true,
                        align: "center",
                    }               
                },
                grid: {
                    aboveData: true,
                    hoverable: true,
                    borderWidth: 0
                },
                xaxis: {
                    mode: "categories",
                    tickLength: 0,
                    labelAngle: -45,
                    showAsHtml: true
                },
                yaxis: {
                    show: false,
                    tickLength: 0
                },
            });
    });

/////////////// #flot-bar-chart-content ////////////////////
    $(document).ready(function(){
        var data = [{data: [["1", 120100], ["22013", 134526], ["22014", 228504], ["20215", 3202000], ["20126", 292977]]}];
        $.plot("#flot-bar-chart-pr", data, {
                series: {
                    color: "#1ab394",
                    // grow: {
                    //  active: true,
                    //  stepMode: "maximum"
                    // },
                    bars: {
                        show: true,
                        align: "center",
                        barWidth: .9,
                        fill: 1     
                    },
                    valueLabels: {
                        show: true,
                        showAsHtml: true,
                        align: "center",
                    }               
                },
                grid: {
                    aboveData: true,
                    hoverable: true,
                    borderWidth: 0
                },
                xaxis: {
                    mode: "categories",
                    tickLength: 0,
                    labelAngle: -45,
                    showAsHtml: true
                },
                yaxis: {
                    show: false,
                    tickLength: 0
                },
            });
    });

/////////////// #flot-line-chart-moving2 ////////////////////
    $(function() {

        var container = $("#flot-line-chart-moving2");

        // Determine how many data points to keep based on the placeholder's initial size;
        // this gives us a nice high-res plot while avoiding more than one point per pixel.

        var maximum = container.outerWidth() / 2 || 300;

        //

        var data = [];

        function getRandomData() {

            if (data.length) {
                data = data.slice(1);
            }

            while (data.length < maximum) {
                var previous = data.length ? data[data.length - 1] : 50;
                var y = previous + Math.random() * 10 - 5;
                data.push(y < 0 ? 0 : y > 100 ? 100 : y);
            }

            // zip the generated y values with the x values

            var res = [];
            for (var i = 0; i < data.length; ++i) {
                res.push([i, data[i]])
            }

            return res;
        }

        series = [{
            data: getRandomData(),
            lines: {
                fill: true
            }
        }];


        var plot = $.plot(container, series, {
            grid: {

                color: "#999999",
                tickColor: "#fff",
                borderWidth:0,
                minBorderMargin: 20,
                labelMargin: 10,
                backgroundColor: {
                    colors: ["#ffffff", "#ffffff"]
                },
                margin: {
                    top: 8,
                    bottom: 20,
                    left: 20
                },
                markings: function(axes) {
                    var markings = [];
                    var xaxis = axes.xaxis;
                    for (var x = Math.floor(xaxis.min); x < xaxis.max; x += xaxis.tickSize * 2) {
                        markings.push({
                            xaxis: {
                                from: x,
                                to: x + xaxis.tickSize
                            },
                            color: "#fff"
                        });
                    }
                    return markings;
                }
            },
            colors: ["#04be77"],
            xaxis: {
                tickFormatter: function() {
                    return "";
                }
            },
            yaxis: {
                min: 0,
                max: 110
            },
            legend: {
                show: true
            }
        });

        // Update the random dataset at 25FPS for a smoothly-animating chart

        setInterval(function updateRandom() {
            series[0].data = getRandomData();
            plot.setData(series);
            plot.draw();
        }, 40);

    });

/////////////// #line-Chart ////////////////////
        $(document).ready(function () {

            c3.generate({
                bindto: '#lineChart',
                data:{
                    columns: [
                        ['Net Income', 30, 200, 100, 300, 150, 250],
                        ['Total Revenue', 50, 20, 10, 40, 15, 25]
                    ],
                    colors:{
                        data1: '#187bb8',
                        data2: '#ff931c'
                    }
                }
            });
        });

/////////////// #line-Chart-SideBar ////////////////////
        $(document).ready(function () {

            c3.generate({
                bindto: '#lineChartsidebar',
                data:{
                    columns: [
                        ['Facebook', 10, 10, 5, 50, 70, 50],
                        ['Twitter', 1, 1, 40, 40, 15, 25]
                    ],
                    colors:{
                        data1: '#187bb8',
                        data2: '#ff931c'
                    }
                },
            });
        });

/////////////// #Welcome-Message ////////////////////
        $(document).ready(function() {
            setTimeout(function() {
                toastr.options = {
                    closeButton: true,
                    progressBar: true,
                    showMethod: 'slideDown',
                    timeOut: 4000
                };
                toastr.info('Responsive Dashboard', 'Welcome to Z2DATA');

            }, 1300);
        });

/////////////// #morris-bar-chart-Financial-Summary ////////////////////
    Morris.Bar({
        element: 'morris-bar-chart',
        data: [
            { y: 'FY2011', a: 60, b: 50 },
            { y: 'FY2012', a: 75, b: 65 },
            { y: 'FY2013', a: 50, b: 40 },
            { y: 'FY2014', a: 75, b: 65 },
            { y: 'FY2015', a: 50, b: 40 },
            { y: 'FY2016', a: 75, b: 65 },
            { y: 'LTM', a: 100, b: 90 }
             ],
        xkey: 'y',
        ykeys: ['a', 'b'],
        labels: ['Net Income', 'Total Revenue'],
        hideHover: 'auto',
        resize: true,
        barColors: ['#ce416c', '#993366'],
    });

/////////////// #morris-bar-chart-Financial-Page ////////////////////
    Morris.Bar({
        element: 'morris-bar-chart-financial',
        data: [
            { y: 'FY2011', a: 60, b: 50 },
            { y: 'FY2012', a: 75, b: 65 },
            { y: 'FY2013', a: 50, b: 40 },
            { y: 'FY2014', a: 75, b: 65 },
            { y: 'FY2015', a: 50, b: 40 },
            { y: 'FY2016', a: 75, b: 65 },
            { y: 'LTM', a: 100, b: 90 }
             ],
        xkey: 'y',
        ykeys: ['a', 'b'],
        labels: ['Net Income', 'Total Revenue'],
        hideHover: 'auto',
        resize: true,
        barColors: ['#ce416c', '#993366'],
    });

/////////////// #morris-bar-chart-revenue-trend ////////////////////
    Morris.Bar({
        element: 'revenue-trend',
        data: [
            { y: '2011', a: 60, b: 50 },
            { y: '2012', a: 75, b: 65 },
            { y: '2013', a: 50, b: 40 },
            { y: '2014', a: 75, b: 65 },
            { y: '2015', a: 50, b: 40 }
             ],
        xkey: 'y',
        ykeys: ['a', 'b'],
        labels: ['Computing and Graphics', 'Enterprise, Embedded and Semi-Custom'],
        hideHover: 'auto',
        resize: true,
        barColors: ['#4573c6', '#ef7e31'],
    });    

/////////////// #morris-bar-chart-geographic-segmentation ////////////////////
    Morris.Bar({
        element: 'geographic-segmentation',
        data: [
            { y: '2012', a: 60, b: 50, c: 50, d: 50 },
            { y: '2013', a: 75, b: 65, c: 50, d: 50 },
            { y: '2014', a: 50, b: 40, c: 50, d: 50 },
            { y: '2015', a: 75, b: 65, c: 50, d: 50 }
             ],
        xkey: 'y',
        ykeys: ['a', 'b', 'c', 'd'],
        labels: ['America', 'Europe', 'Asia', 'Rest World'],
        hideHover: 'auto',
        resize: true,
        barColors: ['#2f62bb', '#ef7421', '#939393', '#fcc400'],
    });


//////////