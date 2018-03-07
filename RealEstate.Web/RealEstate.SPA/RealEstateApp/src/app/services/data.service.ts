import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class DataService{
    Properties:string[];

    constructor(public http:Http){      
    }

    getProperties(){
        return this.http.get('http://localhost:57796/api/Properties')
        .map(res => res.json());
    }
}