import { Component, OnInit } from '@angular/core';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'app-properties',
  templateUrl: './properties.component.html',
  styleUrls: ['./properties.component.css']
})
export class PropertiesComponent implements OnInit {

  properties:any[];
  
      constructor(public dataService:DataService)
      {
        this.dataService.getProperties().subscribe(properties => {
          //console.log(properties);
          this.properties = properties;         
      });
      }
  
  ngOnInit() {
  }

}
