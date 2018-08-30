        $(document).ready(function () {

            c3.generate({
                bindto: '#lineChart',
                data:{
                    columns: [
                        ['data1', 30, 200, 100, 400, 150, 250],
                        ['data2', 50, 20, 10, 40, 15, 25]
                    ],
                    colors:{
                        data1: '#f3a700',
                        data2: '#BABABA'
                    }
                }
            });

            c3.generate({
                bindto: '#slineChart',
                data:{
                    columns: [
                        ['data1', 30, 200, 100, 400, 150, 250],
                        ['data2', 130, 100, 140, 200, 150, 50]
                    ],
                    colors:{
                        data1: '#f3a700',
                        data2: '#BABABA'
                    },
                    type: 'spline'
                }
            });

            c3.generate({
                bindto: '#scatter',
                data:{
                    xs:{
                        data1: 'data1_x',
                        data2: 'data2_x'
                    },
                    columns: [
                        ["data1_x", 3.2, 3.2, 3.1, 2.3, 2.8, 2.8, 3.3, 2.4, 2.9, 2.7, 2.0, 3.0, 2.2, 2.9, 2.9, 3.1, 3.0, 2.7, 2.2, 2.5, 3.2, 2.8, 2.5, 2.8, 2.9, 3.0, 2.8, 3.0, 2.9, 2.6, 2.4, 2.4, 2.7, 2.7, 3.0, 3.4, 3.1, 2.3, 3.0, 2.5, 2.6, 3.0, 2.6, 2.3, 2.7, 3.0, 2.9, 2.9, 2.5, 2.8],
                        ["data2_x", 3.3, 2.7, 3.0, 2.9, 3.0, 3.0, 2.5, 2.9, 2.5, 3.6, 3.2, 2.7, 3.0, 2.5, 2.8, 3.2, 3.0, 3.8, 2.6, 2.2, 3.2, 2.8, 2.8, 2.7, 3.3, 3.2, 2.8, 3.0, 2.8, 3.0, 2.8, 3.8, 2.8, 2.8, 2.6, 3.0, 3.4, 3.1, 3.0, 3.1, 3.1, 3.1, 2.7, 3.2, 3.3, 3.0, 2.5, 3.0, 3.4, 3.0],
                        ["data1", 1.4, 1.5, 1.5, 1.3, 1.5, 1.3, 1.6, 1.0, 1.3, 1.4, 1.0, 1.5, 1.0, 1.4, 1.3, 1.4, 1.5, 1.0, 1.5, 1.1, 1.8, 1.3, 1.5, 1.2, 1.3, 1.4, 1.4, 1.7, 1.5, 1.0, 1.1, 1.0, 1.2, 1.6, 1.5, 1.6, 1.5, 1.3, 1.3, 1.3, 1.2, 1.4, 1.2, 1.0, 1.3, 1.2, 1.3, 1.3, 1.1, 1.3],
                        ["data2", 2.5, 1.9, 2.1, 1.8, 2.2, 2.1, 1.7, 1.8, 1.8, 2.5, 2.0, 1.9, 2.1, 2.0, 2.4, 2.3, 1.8, 2.2, 2.3, 1.5, 2.3, 2.0, 2.0, 1.8, 2.1, 1.8, 1.8, 1.8, 2.1, 1.6, 1.9, 2.0, 2.2, 1.5, 1.4, 2.3, 2.4, 1.8, 1.8, 2.1, 2.4, 2.3, 1.9, 2.3, 2.5, 2.3, 1.9, 2.0, 2.3, 1.8]
                    ],
                    colors:{
                        data1: '#f3a700',
                        data2: '#BABABA'
                    },
                    type: 'scatter'
                }
            });

            c3.generate({
                bindto: '#stocked',
                data: {
                    x : 'x',
                    columns: [
                        ['x', '2010', '2011', '2012', '2013', '2014', '2015', '2016', '2017'],
                        ['Executives Comompensation', 30,80,70,90,99,11,20,80],
                        ['Director Comompensation', 50,20,10,40,15,25,80,10],
                    ],
                    colors:{
                        'Executives Comompensation': '#235b6d',
                        'Director Comompensation': '#d9af3c'
                    },
                    type: 'bar',
                    groups: [
                        ['Executives Comompensation', 'Director Comompensation']
                    ]
                },
                axis: {
                    x: {
                        tick: {
                            multiline: false
                        },
                    }
                }
            });

            c3.generate({
                bindto: '#businessSegmentationBusiness',
                data: {
                    x : 'x',
                    columns: [
                        ['x', '2011', '2012', '2013', '2014', '2015'],
                        ['Performance Materials', 10, 10, 10, 10, 10],
                        ['Wireless Systems', 6, 6, 6, 6, 6]
                    ],
                    colors:{
                        'Performance Materials': '#5b9bd5',
                        'Wireless Systems': '#ed7d31'                  
                    },
                    type: 'bar'
                },
                bar: {
                    width: {
                        ratio: 0.6 // this makes bar width 50% of length between ticks
                    }
                    // or
                    //width: 100 // this makes bar width 100px
                },
                size: {
                  height: 220
                }
            });

            c3.generate({
                bindto: '#businessSegmentationExCustomers',
                data: {
                    x : 'x',
                    columns: [
                        ['x', '2011', '2012', '2013', '2014', '2015'],
                        ['Performance Materials', 10, 10, 10, 10, 10],
                        ['Wireless Systems', 6, 6, 6, 6, 6]
                    ],
                    colors:{
                        'Performance Materials': '#5b9bd5',
                        'Wireless Systems': '#ed7d31'                  
                    },
                    type: 'bar'
                },
                bar: {
                    width: {
                        ratio: 0.6 // this makes bar width 50% of length between ticks
                    }
                    // or
                    //width: 100 // this makes bar width 100px
                },
                size: {
                  height: 220
                }
            });

            c3.generate({
                bindto: '#businessSegmentationProducts',
                data: {
                    x : 'x',
                    columns: [
                        ['x', '2011', '2012', '2013', '2014', '2015'],
                        ['EMI Shielding', 10, 10, 10, 10, 10],
                        ['Telematics/Wireless Modules', 6, 6, 6, 6, 6],
                        ['Thermal', 6, 6, 6, 6, 6],
                        ['Wireless Automation and Control', 5, 5, 5, 5, 5],
                        ['Infrastructure Antennae', 4, 4, 4, 4, 4],
                        ['Signal integrity', 4, 4, 4, 4, 4]
                    ],
                    colors:{
                        'EMI Shielding': '#6fa6d7',
                        'Telematics/Wireless Modules': '#ed8d4d',
                        'Thermal': '#aeaeae',
                        'Wireless Automation and Control': '#fcc623',
                        'Infrastructure Antennae': '#5c83c9',
                        'Signal integrity': '#82b65f'                  
                    },
                    type: 'bar'
                },
                bar: {
                    width: {
                        ratio: 0.8 // this makes bar width 50% of length between ticks
                    }
                    // or
                    //width: 100 // this makes bar width 100px
                },
                size: {
                  height: 360
                }
            });

            c3.generate({
                bindto: '#geographicSegmentationRegion',
                data: {
                    x : 'x',
                    columns: [
                        ['x', '2011', '2012', '2013', '2014', '2015'],
                        ['North America', 10, 10, 10, 10, 10],
                        ['Europe', 6, 6, 6, 6, 6],
                        ['Asia', 4, 4, 4, 4, 4],
                        ['Rest of World', 4, 4, 4, 4, 4]
                    ],
                    colors:{
                        'North America': '#6fa6d7',
                        'Europe': '#ed8d4d',
                        'Thermal': '#aeaeae',
                        'Asia': '#fcc623',
                        'Rest of World': '#5c83c9'                
                    },
                    type: 'bar'
                },
                bar: {
                    width: {
                        ratio: 0.8 // this makes bar width 50% of length between ticks
                    }
                    // or
                    //width: 100 // this makes bar width 100px
                },
                size: {
                  height: 300
                }
            });


            c3.generate({
                
                bindto: '#stockedproducts',
                data: {
                    x : 'x',
                    columns: [
                        ['x', '2010', '2011', '2012', '2013', '2014', '2015', '2016', '2017'],
                        ['Analog', 30,80,70,90,99,11,20,80],
                        ['Other', 50,20,10,40,15,25,80,10],
                        ['Embedded Processing', 50,20,10,40,15,25,80,10],
                    ],
                    colors:{
                        'Analog': '#993366',
                        'Embedded Processing': '#cf3c6d',   
                        'Other': '#ff9966'                     
                    },
                    type: 'bar',
                    groups: [
                        ['Analog', 'Embedded Processing', 'Other']
                    ]
                },
                axis: {
                    x: {
                        tick: {
                            multiline: false
                        },
                    }
                }
            });

            c3.generate({
                
                bindto: '#HistoryForecast',
                data: {
                    x : 'x',
                    columns: [
                        ['x', 'Previous Year', 'Today', ' 2 Years', '3 Years', '5 Years'],
                        ['Strong', 50,20,10,40,15],
                        ['Stable', 30,28,35,9,9],
                        ['Weak', 45,20,5,4,3],
                    ],
                    colors:{
                        Stable: '#e67e22',
                        Weak: '#e74c3c',
                        Strong: '#1abc9c'
                    },
                    type: 'bar',
                    groups: [
                        ['Weak', 'Stable', 'Strong']
                    ],
                    order: 'null'
                },
                axis: {
                    x: {
                        type: 'category',
                        tick: {
                            max: 40
                        },
                        height:50,
                    },
                }
            });

            c3.generate({
                bindto: '#SupplierScoreHistory',
                data: {                    
                    x : 'x',
                    columns: [
                        ['x', 'FY2011', 'FY2012', 'FY2013', 'FY2014', 'FY2015', 'FY2016', 'FY2017'],
                        ['Strong', 0, 65, 0, 65, 95, 70, 22],
                        ['Stable', 0, 95, 0, 89, 92, 88, 78],
                        ['Weak', 0, 80, 70, 90, 53, 50, 20],
                        ['NA', 0, 25, 22, 21, 25, 25, 20],
                    ],
                    colors:{
                        Stable: '#f8ac59',
                        Strong: '#22b66e',
                        Weak: '#b62222',
                        NA: '#999999',
                    },
                    types: {
                        Stable: 'area',
                        Strong: 'area',
                        Weak: 'area',
                        NA: 'area',
                    },
                    groups: [['Stable', 'Strong', 'Weak', 'NA']],
                    order: 'null'
                },
                axis: {
                    x: {
                        type: 'category',
                        padding: {
                              left: -0.45,
                              right: -0.35,
                        },
                        height:50,
                    }
                },

            });


            c3.generate({
                bindto: '#stockedDebtMaturities',
                data: {
                    x : 'x',
                    columns: [
                        ['x', '2012-02-01', '2013-03-01', '2014-01-01', '2015-01-01', '2016-01-01', '2017-02-01'],
                        ['Bonds and Notes', 66, 200, 110, 25, 150, 50],
                        ['Revolving Credit', 50, 120, 60, 90, 110, 250],
                        ['Term Loan', 85, 50, 100, 140, 50, 90],
                    ],
                    colors:{
                        'Bonds and Notes': '#ffd276',
                        'Revolving Credit': '#0067c4',   
                        'Term Loan': '#20ad69'                     
                    },
                    type: 'bar',
                    labels: {
                        format: {
                            'Bonds and Notes': function (value, ratio, id) {
                                var format = id === 'data1' ? d3.format(',') : d3.format('$');
                                return format(value)+'B';
                            },
                            'Revolving Credit': function (value, ratio, id) {
                                var format = id === 'data1' ? d3.format(',') : d3.format('$');
                                return format(value)+'B';
                            },
                            'Term Loan': function (value, ratio, id) {
                                var format = id === 'data1' ? d3.format(',') : d3.format('$');
                                return format(value)+'B';
                            }
                        }
                    },
                    groups: [
                        ['Bonds and Notes', 'Revolving Credit', 'Term Loan']
                    ]
                },
                tooltip: {
                    format: {
                        value: function (value, ratio, id) {
                            var format = id === 'data1' ? d3.format(',') : d3.format('$');
                            return format(value)+'B';
                        }
                        // value: d3.format(',') // apply this format to both y and y2
                    }
                },
                axis: {
                    y : {
                        tick: {
                            format: d3.format("$")
                        }
                    },
                    x: {
                        type : 'timeseries',
                        tick: {
                            multiline: false,
                             //format: function (x) { return x.getFullYear(); }
                            format: '%m-%Y' // format string is also available for timeseries data
                        },
                    }
                }
            });


            c3.generate({
                bindto: '#AllMinerals',
                data: {
                    x : 'x',
                    columns: [
                        ['x', '2010-01-01', '2011-01-01', '2012-01-01', '2013-01-01', '2014-01-01', '2015-01-01', '2016-01-01', '2017-01-01'],
                        ['Identified Smelters', 60, 250, 50, 120, 60, 90, 110, 250],
                        ['Smelters Participating in Third Party Audit', 140, 90, 85, 50, 100, 140, 50, 90],
                    ],
                    colors:{
                        'Identified Smelters': '#082948',   
                        'Smelters Participating in Third Party Audit': '#20ad69'                     
                    },
                    type: 'bar',
                    labels: {
                        format: {
                            'Identified Smelters': function (value, ratio, id) {
                                var format = id === 'data1' ? d3.format(',') : d3.format('');
                                return format(value)+'';
                            },
                            'Smelters Participating in Third Party Audit': function (value, ratio, id) {
                                var format = id === 'data1' ? d3.format(',') : d3.format('');
                                return format(value)+'';
                            }
                        }
                    },
                    groups: [
                        ['Identified Smelters', 'Smelters Participating in Third Party Audit']
                    ]
                },
                tooltip: {
                    format: {
                        value: function (value, ratio, id) {
                            var format = id === 'data1' ? d3.format(',') : d3.format('');
                            return format(value)+'';
                        }
                        // value: d3.format(',') // apply this format to both y and y2
                    }
                },
                axis: {
                    y : {
                        tick: {
                            format: d3.format("$")
                        }
                    },
                    x: {
                        type : 'timeseries',
                        tick: {
                            multiline: false,
                             //format: function (x) { return x.getFullYear(); }
                            format: '%Y' // format string is also available for timeseries data
                        },
                    }
                }
            });

            
            c3.generate({
                bindto: '#AllMinTin',
                data: {
                    x : 'x',
                    columns: [
                        ['x', '2010-01-01', '2011-01-01', '2012-01-01', '2013-01-01', '2014-01-01', '2015-01-01', '2016-01-01', '2017-01-01'],
                        ['Identified Smelters', 60, 250, 50, 120, 60, 90, 110, 250],
                        ['Smelters Participating in Third Party Audit', 140, 90, 85, 50, 100, 140, 50, 90],
                    ],
                    colors:{
                        'Identified Smelters': '#082948',   
                        'Smelters Participating in Third Party Audit': '#20ad69'                     
                    },
                    type: 'bar',
                    labels: {
                        format: {
                            'Identified Smelters': function (value, ratio, id) {
                                var format = id === 'data1' ? d3.format(',') : d3.format('');
                                return format(value)+'';
                            },
                            'Smelters Participating in Third Party Audit': function (value, ratio, id) {
                                var format = id === 'data1' ? d3.format(',') : d3.format('');
                                return format(value)+'';
                            }
                        }
                    },
                    groups: [
                        ['Identified Smelters', 'Smelters Participating in Third Party Audit']
                    ]
                },
                tooltip: {
                    format: {
                        value: function (value, ratio, id) {
                            var format = id === 'data1' ? d3.format(',') : d3.format('');
                            return format(value)+'';
                        }
                        // value: d3.format(',') // apply this format to both y and y2
                    }
                },
                axis: {
                    y : {
                        tick: {
                            format: d3.format("$")
                        }
                    },
                    x: {
                        type : 'timeseries',
                        tick: {
                            multiline: false,
                             //format: function (x) { return x.getFullYear(); }
                            format: '%Y' // format string is also available for timeseries data
                        },
                    }
                }
            });
            c3.generate({
                bindto: '#AllMinTungsten',
                data: {
                    x : 'x',
                    columns: [
                        ['x', '2010-01-01', '2011-01-01', '2012-01-01', '2013-01-01', '2014-01-01', '2015-01-01', '2016-01-01', '2017-01-01'],
                        ['Identified Smelters', 60, 250, 50, 120, 60, 90, 110, 250],
                        ['Smelters Participating in Third Party Audit', 140, 90, 85, 50, 100, 140, 50, 90],
                    ],
                    colors:{
                        'Identified Smelters': '#082948',   
                        'Smelters Participating in Third Party Audit': '#20ad69'                     
                    },
                    type: 'bar',
                    labels: {
                        format: {
                            'Identified Smelters': function (value, ratio, id) {
                                var format = id === 'data1' ? d3.format(',') : d3.format('');
                                return format(value)+'';
                            },
                            'Smelters Participating in Third Party Audit': function (value, ratio, id) {
                                var format = id === 'data1' ? d3.format(',') : d3.format('');
                                return format(value)+'';
                            }
                        }
                    },
                    groups: [
                        ['Identified Smelters', 'Smelters Participating in Third Party Audit']
                    ]
                },
                tooltip: {
                    format: {
                        value: function (value, ratio, id) {
                            var format = id === 'data1' ? d3.format(',') : d3.format('');
                            return format(value)+'';
                        }
                        // value: d3.format(',') // apply this format to both y and y2
                    }
                },
                axis: {
                    y : {
                        tick: {
                            format: d3.format("$")
                        }
                    },
                    x: {
                        type : 'timeseries',
                        tick: {
                            multiline: false,
                             //format: function (x) { return x.getFullYear(); }
                            format: '%Y' // format string is also available for timeseries data
                        },
                    }
                }
            });
            c3.generate({
                bindto: '#AllMinTantalum',
                data: {
                    x : 'x',
                    columns: [
                        ['x', '2010-01-01', '2011-01-01', '2012-01-01', '2013-01-01', '2014-01-01', '2015-01-01', '2016-01-01', '2017-01-01'],
                        ['Identified Smelters', 60, 250, 50, 120, 60, 90, 110, 250],
                        ['Smelters Participating in Third Party Audit', 140, 90, 85, 50, 100, 140, 50, 90],
                    ],
                    colors:{
                        'Identified Smelters': '#082948',   
                        'Smelters Participating in Third Party Audit': '#20ad69'                     
                    },
                    type: 'bar',
                    labels: {
                        format: {
                            'Identified Smelters': function (value, ratio, id) {
                                var format = id === 'data1' ? d3.format(',') : d3.format('');
                                return format(value)+'';
                            },
                            'Smelters Participating in Third Party Audit': function (value, ratio, id) {
                                var format = id === 'data1' ? d3.format(',') : d3.format('');
                                return format(value)+'';
                            }
                        }
                    },
                    groups: [
                        ['Identified Smelters', 'Smelters Participating in Third Party Audit']
                    ]
                },
                tooltip: {
                    format: {
                        value: function (value, ratio, id) {
                            var format = id === 'data1' ? d3.format(',') : d3.format('');
                            return format(value)+'';
                        }
                        // value: d3.format(',') // apply this format to both y and y2
                    }
                },
                axis: {
                    y : {
                        tick: {
                            format: d3.format("$")
                        }
                    },
                    x: {
                        type : 'timeseries',
                        tick: {
                            multiline: false,
                             //format: function (x) { return x.getFullYear(); }
                            format: '%Y' // format string is also available for timeseries data
                        },
                    }
                }
            });
            c3.generate({
                bindto: '#AllMinGold',
                data: {
                    x : 'x',
                    columns: [
                        ['x', '2010-01-01', '2011-01-01', '2012-01-01', '2013-01-01', '2014-01-01', '2015-01-01', '2016-01-01', '2017-01-01'],
                        ['Identified Smelters', 60, 250, 50, 120, 60, 90, 110, 250],
                        ['Smelters Participating in Third Party Audit', 140, 90, 85, 50, 100, 140, 50, 90],
                    ],
                    colors:{
                        'Identified Smelters': '#082948',   
                        'Smelters Participating in Third Party Audit': '#20ad69'                     
                    },
                    type: 'bar',
                    labels: {
                        format: {
                            'Identified Smelters': function (value, ratio, id) {
                                var format = id === 'data1' ? d3.format(',') : d3.format('');
                                return format(value)+'';
                            },
                            'Smelters Participating in Third Party Audit': function (value, ratio, id) {
                                var format = id === 'data1' ? d3.format(',') : d3.format('');
                                return format(value)+'';
                            }
                        }
                    },
                    groups: [
                        ['Identified Smelters', 'Smelters Participating in Third Party Audit']
                    ]
                },
                tooltip: {
                    format: {
                        value: function (value, ratio, id) {
                            var format = id === 'data1' ? d3.format(',') : d3.format('');
                            return format(value)+'';
                        }
                        // value: d3.format(',') // apply this format to both y and y2
                    }
                },
                axis: {
                    y : {
                        tick: {
                            format: d3.format("$")
                        }
                    },
                    x: {
                        type : 'timeseries',
                        tick: {
                            multiline: false,
                             //format: function (x) { return x.getFullYear(); }
                            format: '%Y' // format string is also available for timeseries data
                        },
                    }
                }
            });

            c3.generate({
                bindto: '#Historicaloverallscore',
                data: {
                    x : 'x',
                    columns: [
                        ['x', '2010-02-01', '2011-03-01', '2012-01-01', '2013-01-01', '2014-01-01', '2015-05-01', '2016-05-02', '2017-05-03'],
                        ['Overall Score', 66, 200, 110, 25, 140, 50, 125, 150]
                    ],
                    colors:{
                        'Overall Score': '#1b97a6'                 
                    },
                    type: 'bar',
                    bar: {
                        width: {
                            ratio: 100 // this makes bar width 50% of length between ticks
                        }
                        // or
                        //width: 100 // this makes bar width 100px
                    },
                    groups: [
                        ['Overall Score']
                    ]
                },
                axis: {
                    x: {
                        type : 'timeseries',
                        tick: {
                            multiline: false,
                             //format: function (x) { return x.getFullYear(); }
                            format: '%m-%Y' // format string is also available for timeseries data
                        },
                    }
                }
            });

            c3.generate({
                bindto: '#stockedIssuanceDate',
                data: {
                    x : 'x',
                    columns: [
                        ['x', 'Commercial paper Aug-17', 'Current Maturities May-19', 'Term Loan Aug-22', 'Revolving Credit Sep-26'],
                        ['Issuance Date', 70, 10, 30, 50],
                    ],
                    colors:{
                        'Issuance Date': '#993366'                   
                    },
                    type: 'bar'
                },
                axis: {
                    x: {
                        type: 'category',
                        tick: {
                            max: 40
                        },
                        height:50,
                    },
                }
            });

            c3.generate({
                bindto: '#DebttoEquityPie',
                data:{
                    columns: [
                        ['Equity', 41],
                        ['debt', 59]
                    ],
                    colors:{
                        'Equity': '#20ad69',
                        'short term debt': '#6b6b6b'
                    },
                    type : 'pie'
                },
                tooltip: {
                    format: {
                        value: function (value, ratio, id) {
                            var format = id === 'data1' ? d3.format(',') : d3.format('$');
                            return format(value)+'B';
                        }
                        // value: d3.format(',') // apply this format to both y and y2
                    }
                }
            });

            c3.generate({
                bindto: '#DebttoEquityPieTow',
                data:{
                    columns: [
                        ['Senior', 40],
                        ['Secured', 60]
                    ],
                    colors:{
                        'Senior': '#20ad69',
                        'Secured': '#6b6b6b'
                    },
                    type : 'pie'
                },
                tooltip: {
                    format: {
                        value: function (value, ratio, id) {
                            var format = id === 'data1' ? d3.format(',') : d3.format('$');
                            return format(value)+'B';
                        }
                        // value: d3.format(',') // apply this format to both y and y2
                    }
                }
            });

            c3.generate({
                bindto: '#gauge',
                data:{
                    columns: [
                        ['data', 91.4]
                    ],

                    type: 'gauge'
                },
                color:{
                    pattern: ['#bcbd22', '#BABABA']

                }
            });

            c3.generate({
                bindto: '#RiskManagerPartsPie',
                size: {
                    height: 200,
                    width: 250
                },
                data:{
                    columns: [
                        ['UnitedStates', 40],
                        ['China', 30],
                        ['Jordan', 30]
                    ],
                    colors:{
                        UnitedStates: '#474673',
                        China: '#e3d16b',
                        Jordan: '#d44bae'
                    },
                    type : 'pie'
                }
            });

            c3.generate({
                bindto: '#RiskManagerSuppliersPie',
                size: {
                    height: 320,
                    width: 350
                },
                data:{
                    columns: [
                        ['Public', 6276],
                        ['Private', 1000],
                        ['Direct', 455],
                        ['Indirect', 403],
                        ['NA', 200]
                    ],
                    colors:{
                        Public: '#ed0000',
                        Private: '#ff8500',
                        Direct: '#1c84c6',
                        Indirect: '#20ad69',
                        NA: '#6b6b6b'
                    },
                    type : 'pie'
                },
                pie: {
                    label: {
                      format: function(value, ratio, id) {
                        return value;
                      }
                    }
                },
                tooltip:{
                    format:{
                        value:function(x){
                        return x;
                        }
                     }
                }
            });

            c3.generate({
                bindto: '#RiskManagerCompaniesPie',
                data:{
                    columns: [
                        ['Strong', 40],
                        ['Stable', 30],
                        ['Weak', 30]
                    ],
                    colors:{
                        Strong: '#20ad69',
                        Stable: '#6b6b6b',
                        Weak: '#b62222'
                    },
                    type : 'pie'
                }
            });

            c3.generate({
                bindto: '#IndependenceDirectorsPie',
                data:{
                    columns: [
                        ['Exective and Director', 8],
                        ['Independence Director', 92]
                    ],
                    colors:{
                        'Exective and Director': '#bcbd22',
                        'Independence Director': '#159dc3'
                    },
                    type : 'pie'
                }
            });

            c3.generate({
                bindto: '#DirectorsAgePie',
                data:{
                    columns: [
                        ['53', 10],
                        ['62', 10],
                        ['63', 10],
                        ['64', 10],
                        ['65', 10],
                        ['66', 10],
                        ['67', 10],
                        ['69', 10],
                        ['70', 10]
                    ],
                    colors:{
                        53: '#1a806a',
                        62: '#fdcd52',
                        63: '#cb9a2e',
                        64: '#3c4157',
                        65: '#c46850',
                        66: '#686a70',
                        67: '#c05477',
                        69: '#235b6d',
                        70: '#8093ab'
                    },
                    type : 'pie'
                },
                pie: {
                    label: {
                      format: function(value, ratio, id) {
                        return value;
                      }
                    }
                },
                tooltip:{
                    format:{
                        value:function(x){
                        return x;
                        }
                     }
                }
            });

            c3.generate({
                bindto: '#ScoreHistory',
                data: {
                    x : 'x',
                    columns: [
                        ['x', 'FY2011', 'FY2012', 'FY2013', 'FY2014', 'FY2015', 'FY2016', 'LTM'],
                        ['Score', 80, 90, 100, 50, 40, 70, 60]
                    ],
                    type: 'bar',
                    labels: {
                        format: function (v, id) {
                            if (v === null) {
                                return 'Not Applicable';
                            }
                            return d3.format(',')(v);
                        }
                    },
                    colors: {
                        'Score': function(d) { 
                            if(d.value < 51){
                                return '#b62222';
                            }else if(d.value < 75 && d.value > 50){
                                return '#f8ac59';
                            }else {
                                return '#22b66e';
                            }
                        }
                    },
                },
                axis: {
                    x: {
                        type: 'category'
                    },
                    y: {
                        show: false,
                    }
                }, 
                bar: {
                    width: {
                        ratio: 0.9 // this makes bar width 50% of length between ticks
                    }
                    // or
                    //width: 100 // this makes bar width 100px
                }
            });
            
            c3.generate({
                bindto: '#mostafa',
                data: {
                    x: 'x',
                    columns: [
                        ['x', '2012', '2013', '2014', '2015', '2016', 'LTM'],
                        ['Stoke Price', 5, 3, 4, -3, 6, 5],
                        ['Market Cap', 500, 450, 490, 420, 380, 350]
                    ],
                    colors:{
                        'Market Cap': '#E5D25C',
                        'Stoke Price': '#0A58A6' 
                    },
                    axes: {
                     'Stoke Price': 'y2'
                    },
                    type: 'bar',
                    types: {
                      'Stoke Price': 'line'
                    },
                },
                bar: {                    
                        width: 120 // this makes bar width 100px
                        //ratio: 0.1 // this makes bar width 50% of length between ticks
                    
                    // ratio: 0.1 // this makes bar width 50% of length between ticks
                    //width: 100 // this makes bar width 100px
                },
                tooltip: {
                    format: {
                        value: function (value, ratio, id) {
                            var format = id === 'data1' ? d3.format(',') : d3.format('$');
                            return format(value)+'M';
                        }
                        // value: d3.format(',') // apply this format to both y and y2
                    }
                },
                axis: {
                    x: {
                        type: 'category'
                    },
                    y: {
                        label: {
                            text: 'Market Cap',
                            position: 'outer-middle'
                        },
                        tick: {
                            format: function (d) { return "$" + d + "M"; }
                        }
                    },
                    y2: {
                        show: true,
                        label: {
                            text: 'Stoke Price',
                            position: 'outer-middle'
                        },
                        tick: {
                            format: function (d) { return "$" + d + "M"; }
                        },
                        max: 30,
                        min: -10
                    }
                }
            });


        });