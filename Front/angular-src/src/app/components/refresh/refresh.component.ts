import {Component, OnInit} from '@angular/core';
import {Router, ActivatedRoute, Params} from '@angular/router';

@Component({
  selector: 'app-refresh',
  template: `
    <p>
      refresh Works!
    </p>
  `,
  styles: []
})
export class RefreshComponent implements OnInit {

  constructor(private activatedRoute: ActivatedRoute, private route: Router) {
  }

  ngOnInit() {
    this.activatedRoute
      .queryParams
      .subscribe(params => {
        if (params.url) {
          this.route.navigate([params.url]);
        }
      });
  }
}
