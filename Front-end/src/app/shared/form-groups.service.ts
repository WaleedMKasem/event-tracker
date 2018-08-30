import { Injectable } from '@angular/core';
import { Validators, FormBuilder, FormControl, FormArray } from '@angular/forms';

@Injectable()
export class FormGroupService {

  constructor(protected _fb: FormBuilder) { }

  initDetails() {
    // initialize our details
    return this._fb.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      category: this.initCategory(),
      type: this.initType(),
      startDate: [null, Validators.required],
      // startDate: [new Date(), Validators.required],
      sources: [''],
      severity: [-1, Validators.required],
      status: [-1, Validators.required],
      statusPercentage: [''],
    });
  }
  initType() {
    // initialize our category
    return this._fb.group({
      id: [-1, Validators.required]
    });
  }
  initCategory() {
    // initialize our category
    return this._fb.group({
      id: [-1, Validators.required]
    });
  }
  initCountry() {
    // initialize our category
    return this._fb.group({
      countryId: [-1, Validators.required]
    });
  }
  initCity() {
    // initialize our category
    return this._fb.group({
      cityId: [-1]
    });
  }
  initState() {
    // initialize our category
    return this._fb.group({
      stateId: [-1]
    });
  }
  initPlace() {
    // initialize our category
    return this._fb.group({
      country: this.initCountry(),
      state: this.initState(),
      city: this.initCity(),
      other: ['']
    });
  }

  initFeatures() {
    return this._fb.group({
      value: [],
      unit: [''],
      populationAffected: [],
      populationDeaths: [],
      populationMissing: [],
      acresBurned: [],
      damageInMillionUsd: [],
      damageInProperty: [''],
      insuredLosses: [],
      notes: ['']
    });
  }

  initOptionalLocation() {
    return this._fb.group({
      coordinates: this._fb.array([[''], ['']])
    });
  }
  initLocation() {
    return this._fb.group({
      coordinates: this.initCoordinates()
    });
  }
  initCoordinates() {
    return this._fb.array([['', Validators.required], ['', Validators.required]]);
    //   return  new FormArray([
    //     new FormControl(0,Validators.required),
    //     new FormControl(0,Validators.required)
    //  ]);
    // this._fb.array([
    //     this._formGroupService.initAffectedLocation()
    //   ]);
  }
  initEffectRange() {
    return this._fb.group({
      affectedRadius: ['', Validators.required],
      nearRadius: ['', Validators.required],
      location: this.initLocation()
    });
  }
  initOptionalEffectRange() {
    return this._fb.group({
      affectedRadius: [''],
      nearRadius: [''],
      location: this.initOptionalLocation()
    });
  }

  initAssociatedEvent() {
    return this._fb.group({
      category: this.initCategory(),
      type: this.initType(),
      severity: [-1],
      effectRange: this.initOptionalEffectRange(),
      categoryStatus: [-1]
    });
  }

  initDisasterTypes() {
    return this._fb.group({
      Id: [-1]
    });
  }

  initAffectedLocation() {
    return this._fb.group({
      locationId: [''],
      name: [''],
      location: this.initLocation(),
      type: [''],
      locationType: [''],
      iata: [''],
      locode: [''],
      disasterTypes: this.initDisasterTypes(),
      distance: [0],
      associatedDistance: [],
      status: [''],
      isConfirmed: [false]
    });
  }
}
