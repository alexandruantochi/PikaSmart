import {Component, Directive, ElementRef, HostListener, Input, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import * as Chartist from 'chartist';
import { IntervalObservable } from 'rxjs/observable/IntervalObservable';
@Component({
  selector: '[widgetElem]',
  templateUrl: './widget.component.html',

})

export class WidgetComponent implements OnInit {
  private data: any;
  public name: any;
  public chosenType: any;
  public colors = ['green', 'orange', 'red', 'blue', 'purple'];
  private days: any;
  private months: any;
  private hours: any;
  public chartTypes: any;
  public lastDate:any;
  public val_increase:any;
  constructor(private el: ElementRef, private http: HttpClient) {
    this.chartTypes = ['Daily', 'Monthly', 'Hourly'];
    this.hours = ['12am', '3pm', '6pm', '9pm', '12pm', '3am', '6am', '9am'];
    this.months = ['Jan', 'Feb', 'Mar', 'Apr', 'Mai', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
    this.days = ['M', 'T', 'W', 'T', 'F', 'S', 'S'];
  }

  @Input() url: any;
  @Input() index: number;

  startAnimationForLineChart(chart) {
    let seq: any, delays: any, durations: any;
    seq = 0;
    delays = 80;
    durations = 500;

    chart.on('draw', function (data) {
      if (data.type === 'line' || data.type === 'area') {
        data.element.animate({
          d: {
            begin: 600,
            dur: 700,
            from: data.path.clone().scale(1, 0).translate(0, data.chartRect.height()).stringify(),
            to: data.path.clone().stringify(),
            easing: Chartist.Svg.Easing.easeOutQuint
          }
        });
      } else if (data.type === 'point') {
        seq++;
        data.element.animate({
          opacity: {
            begin: seq * delays,
            dur: durations,
            from: 0,
            to: 1,
            easing: 'ease'
          }
        });
      }
    });

    seq = 0;
  };

  getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
  }

  startAnimationForBarChart(chart) {
    let seq2: any, delays2: any, durations2: any;

    seq2 = 0;
    delays2 = 80;
    durations2 = 500;
    chart.on('draw', function (data) {
      if (data.type === 'bar') {
        seq2++;
        data.element.animate({
          opacity: {
            begin: seq2 * delays2,
            dur: durations2,
            from: 0,
            to: 1,
            easing: 'ease'
          }
        });
      }
    });

    seq2 = 0;
  };

  lineChart(dataChart, optionsChart) {
    var Chart = new Chartist.Line('#chart' + this.index, dataChart, optionsChart);
    this.startAnimationForLineChart(Chart);
  }

  barChart(dataChart, optionsChart) {
    var Chart = new Chartist.Bar('#chart' + this.index, dataChart, optionsChart);
    this.startAnimationForBarChart(Chart);
  }

  populate_chart(index) {
    var arr = {
      info: [], nr: []
    };
    this.chosenType=index+1;
    var max = 0;
    this.lastDate=0;
    switch (index) {
      case 0:
        for (let index = 0; index < this.days.length; index++) {
          arr.info[index] = 0;
          arr.nr[index] = 0;
        }
        for (let index in this.data) {
          if(this.lastDate<this.data[index].time){
            this.lastDate=this.data[index].time
          }

          arr.info[this.data[index].time.getDay()] = this.data[index].value;
          arr.nr[this.data[index].time.getDay()] += 1;
        }
        for (let index = 0; index < this.days.length; index++) {
          if (arr.nr[index] != 0) {
            arr.info[index] = arr.info[index] / arr.nr[index];
            if (arr.info[index] > max) {
              max = arr.info[index];
            }
          }
        }

        var dataChart: any = {
          labels: this.days,
          series: [arr.info]
        };

        var optionsChart: any = {
          lineSmooth: Chartist.Interpolation.cardinal({
            tension: 0
          }),
          low: 0,
          high: max +max/3 ,
          chartPadding: {top: 0, right: 0, bottom: 0, left: 0},
        };
        this.lineChart(dataChart, optionsChart);
        break;
      case 1:
        for (let index = 0; index < this.months.length; index++) {
          arr.info[index] = 0;
          arr.nr[index] = 0;
        }
        for (let index in this.data) {
          if(this.lastDate<this.data[index].time){
            this.lastDate=this.data[index].time
          }
          arr.info[this.data[index].time.getMonth()] = this.data[index].value;
          arr.nr[this.data[index].time.getMonth()] += 1;
        }
        for (let index = 0; index < this.months.length; index++) {
          if (arr.nr[index] != 0) {
            arr.info[index] = arr.info[index] / arr.nr[index];

          }
          if (arr.info[index] > max) {
            max = arr.info[index];
          }
        }
        var dataChart: any = {
          labels: this.months,
          series: [arr.info]
        };

        var optionsChart: any = {
          lineSmooth: Chartist.Interpolation.cardinal({
            tension: 0
          }),
          low: 0,
          high: max +max/3 ,
          chartPadding: {top: 0, right: 0, bottom: 0, left: 0},
        };
     this.barChart(dataChart,optionsChart);
        break;
      default:
        for (let index = 0; index < this.hours.length; index++) {
          arr.info[index] = 0;
          arr.nr[index] = 0;
        }
        for (let index in this.data) {
          if(this.lastDate<this.data[index].time){
            this.lastDate=this.data[index].time
          }
          arr.info[this.data[index].time.getHours()%3] = this.data[index].value;
          arr.nr[this.data[index].time.getHours()%3] += 1;
        }
        for (let index = 0; index < this.hours.length; index++) {
          if (arr.nr[index] != 0) {
            arr.info[index] = arr.info[index] / arr.nr[index];
            if (arr.info[index] > max) {
              max = arr.info[index];
            }
          }
        }

        var dataChart: any = {
          labels: this.hours,
          series: [arr.info]
        };

        var optionsChart: any = {
          lineSmooth: Chartist.Interpolation.cardinal({
            tension: 0
          }),
          low: 0,
          high: max +max/3 ,
          chartPadding: {top: 0, right: 0, bottom: 0, left: 0},
        };
        this.lineChart(dataChart, optionsChart);
    }
   this.val_increase=0;
      for(let index = 0; index < arr.info.length-1; index++){
       this.val_increase+=arr.info[index]-arr.info[index+1];
      }

  };
 request(){

  }
  ngOnInit() {

    this.chosenType = this.getRandomInt(1, this.chartTypes.length);
    this.http.get(this.url).subscribe(data => {
        let elem = this.url.split('/');
        this.name = elem[elem.length - 1];
        data[this.name + 'Records'].forEach(record => {
          record.time = new Date(record.time);
        });
        console.log(data);
        this.data = data[elem[elem.length - 1] + 'Records'];


        this.populate_chart(this.chosenType-1);
      }, err => console.error(err),
      () => console.log(this.url, 'received'));

    IntervalObservable
      .create(30000)
      .flatMap((i) =>  this.http.get(this.url)).subscribe(data => {
        let elem = this.url.split('/');
        this.name = elem[elem.length - 1];
        data[this.name + 'Records'].forEach(record => {
          record.time = new Date(record.time);
        });
        console.log(data);
        this.data = data[elem[elem.length - 1] + 'Records'];


        this.populate_chart(this.chosenType-1);
      }, err => console.error(err),
      () => console.log(this.url, 'received'));

  };


}
