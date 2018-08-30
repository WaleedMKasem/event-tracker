import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'map-selector',
    templateUrl: 'map.component.html',
    styleUrls: ['map.component.css']
})

export class MapComponent implements OnInit {
    constructor(protected _activatedRoute: ActivatedRoute) { 
        
    }

    long:number;
    lat:number;
    // src:string;
    // href:string;
    // lat: number = 51.678418;
    // long: number = 7.809007;

    ngOnInit() { 
        
    this._activatedRoute.params.subscribe(params => {
        this.long =Number(params['long']);
        this.lat = Number(params['lat']);
        console.log(this.long);
        console.log(this.lat);
      });
        // this.src="https://maps.google.com/maps?q="+this.long+","+this.lat+"&hl=es;z=14&amp;output=embed/" ;
        // this.href='https://maps.google.com/maps?q='+this.long+','+this.lat+'&hl=es;z=14&amp;output=embed/';
    }
}