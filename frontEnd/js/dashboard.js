function load() {
    checkAuth();
    CommonPost("visita/dashboard", {}, function (data) {
        arrayJson = [];
        contador = {};
        data.forEach(element => {
            if (element.VISITASETOR.Nome in contador) {
                contador[element.VISITASETOR.Nome] += 1
            } else {
                contador[element.VISITASETOR.Nome] = 1
            }
        });

        for (var prop in contador) {
            arrayJson.push({
                name: "Setor " + prop,
                y: (contador[prop] * 100) / data.length
            })
        }

        Highcharts.chart('pieChartVisitas', {
            chart: {
                plotBackgroundColor: null,
                plotBorderWidth: null,
                plotShadow: false,
                type: 'pie'
            },
            title: {
                text: 'Setores mais visitados'
            },
            tooltip: {
                pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
            },
            plotOptions: {
                pie: {
                    allowPointSelect: true,
                    cursor: 'pointer',
                    dataLabels: {
                        enabled: true,
                        format: '<b>{point.name}</b>: {point.percentage:.1f} %'
                    }
                }
            },
            series: [{
                name: 'Total de Visitas',
                colorByPoint: true,
                data: arrayJson
            }]
        });
    });
}

//// Create the chart
//Highcharts.chart('lineChartVisitasHora', {
//    title: {
//        text: 'Fluxo de Pessoas/Hora',
//        x: -20 //center
//    },
//    xAxis: {
//        categories: ['08:00', '09:00', '10:00', '11:00', '12:00', '13:00',
//            '14:00', '15:00', '16:00', '17:00', '18:00', '19:00', '20:00', '21:00',
//            '22:00'
//        ]
//    },
//    yAxis: {
//        title: {
//            text: 'Pessoas (unidade)'
//        },
//        plotLines: [{
//            value: 0,
//            width: 1,
//            color: '#808080'
//        }]
//    },
//    legend: {
//        layout: 'vertical',
//        align: 'right',
//        verticalAlign: 'middle',
//        borderWidth: 0
//    },
//    series: [{
//        name: 'Secretaria',
//        data: [7.0, 6.9, 9.5, 14.5, 18.2, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6, 12.0, 14.0, 18.9]
//    }, {
//        name: 'FabLab',
//        data: [-0.2, 0.8, 5.7, 11.3, 17.0, 22.0, 24.8, 24.1, 20.1, 14.1, 8.6, 2.5]
//    }, {
//        name: 'Tesouraria',
//        data: [-0.9, 0.6, 3.5, 8.4, 13.5, 17.0, 18.6, 17.9, 14.3, 9.0, 3.9, 1.0]
//    }, {
//        name: 'Cantina',
//        data: [3.9, 4.2, 5.7, 8.5, 11.9, 15.2, 17.0, 16.6, 14.2, 10.3, 6.6, 4.8]
//    }]
//});