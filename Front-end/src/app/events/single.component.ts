import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, Validators, FormControl, FormBuilder } from '@angular/forms';
import { Event } from './event.model';
import { FormGroupService } from '../shared/form-groups.service';
import { EventService } from './event.service';
import { EventCategoryService } from '../lookups/event-category.service';
import { Data } from '@angular/router/src/config';
import { Lookup } from '../lookups/lookup';
import { CountryService } from '../lookups/country.service';
import { Country } from '../lookups/country';
import { StateService } from '../lookups/state.service';
import { State } from '../lookups/state';
import { CityService } from '../lookups/city.service';
import { City } from '../lookups/city';
import { ActivatedRoute, Router } from '@angular/router';
import { EventCategory } from '../lookups/event-Category';
import { DatePipe } from '@angular/common';
import { AffectedLocation } from '../events/meta-models/affected-location';
import { AffectedService } from '../locations/affected.service';
import { AffectedLocationType } from '../shared/enums/affected-locationType';
import { Status } from '../shared/enums/status';
import 'rxjs/add/operator/finally';
import { Disaster } from '../lookups/disaster';
import { DisasterService } from '../lookups/disaster.service';
import { IMyDpOptions } from 'mydatepicker';
import { CustomDate } from '../shared/customDate.model';
import { Http } from '@angular/http';
import { Attachment } from './meta-models/attachment';
import { Source } from './meta-models/source';
import { ImportType } from '../shared/enums/import-type';
import { FileService } from '../shared/file.service';

@Component({
    selector: 'single-event',
    templateUrl: 'single.component.html',
    styleUrls: ['./single.component.css']
})

export class SingleEventComponent implements OnInit {
    constructor(private _fb: FormBuilder, protected _activatedRoute: ActivatedRoute, protected _route: Router, protected _formGroupService: FormGroupService,
        protected _eventService: EventService, protected _eventCategoryService: EventCategoryService, protected _countryService: CountryService,
        protected _stateService: StateService, protected _cityService: CityService,
        protected datepipe: DatePipe, protected _affectedService: AffectedService, protected _disasterService: DisasterService,
        protected _fileService: FileService) {

        this._activatedRoute.params.subscribe(params => {
            this.eventId = params['id'];
            this.isUpdate = params['isUpdate'];
            this.subIndex = params['subIndex'];
            console.log('this.isUpdate ' + this.isUpdate); // Print the parameter to the console. 
            console.log('this.eventId ' + this.eventId); // Print the parameter to the console. subIndex
            console.log('this.subIndex ' + this.subIndex); // Print the parameter to the console. subIndex
        });
    }

    // countries: Country[];
    showMoreFeatures: boolean = false;
    showAssociatedCoordinates: boolean = false;
    showAffectedLocations: boolean = false;
    showImporter: boolean = false;
    event: Event;
    eventId: string;
    startDate: Date;
    subIndex: number;
    isUpdate: boolean;
    eventFormGroup: FormGroup;
    categories: EventCategory[];
    eventTypes: Lookup[];
    associatedEventTypes: Lookup[];
    countries: Country[];
    States: State[];
    cities: City[];
    disasters: Disaster[];
    today: Date;
    affectedLocations: AffectedLocation[];
    affectedSuppliers: AffectedLocation[];
    affectedAirports: AffectedLocation[];
    affectedSeaports: AffectedLocation[];
    images: Attachment[];
    attachments: Attachment[];
    sources: Source[];
    isLoadingData: boolean=false;
    statusId: number;
    validationSummary: string;

    public myDatePickerOptions: IMyDpOptions = {
        // other options...
        // dateFormat: 'dd.mm.yyyy',
        dateFormat: 'dd/mm/yyyy'
    };
    ngOnInit() {
        this.initEventGroup();

        this.sources = [];
        this.images = [];
        this.isLoadingData=true;
        this._eventCategoryService.getEventCategories()
            .subscribe(categories => {
                console.log('categories');
                console.log(categories);
                this.categories = categories;

                this._countryService.getCountries()
                    .subscribe(countries => {
                        this.countries = countries;
                        this._disasterService.getDisasters()
                            .subscribe(p => {
                                this.disasters = p;
                                this.loadEvent();
                                this.isLoadingData=false;
                            });

                    });

            });
    }

    loadEvent() {
        if (this.eventId) {
            if (this.isUpdate) {
                if (this.subIndex) {
                    this._eventService.GetSubEvent(this.eventId, this.subIndex)
                        .subscribe(event => {
                            console.log(event);
                            //if (event.details.status === Status.Closed ||
                            //    event.details.status === Status.InActive ||
                            //    (event.details.status === Status.Contained && event.details.statusPercentage === 100)) {
                            //    this._route.navigate(['/events']);
                            //}
                            this.eventTypes = this.categories && this.categories.find(c => c.id == event.details.category.id).eventTypes;
                            if (event.associatedEvent.category) {
                                this.associatedEventTypes = this.categories && this.categories.find(c => c.id == event.associatedEvent.category.id).eventTypes;
                            }

                            this.onSelectCountry(event.place.country.countryId);
                            if(event.place.state){
                                this.onSelectState(event.place.state.stateId);
                            }
                            console.log(this.associatedEventTypes);

                            this.eventFormGroup.patchValue(event);


                            this.affectedLocations = event.affectedLocations || [];
                            this.affectedSuppliers = event.affectedLocations.filter(a => a.type == AffectedLocationType.Company) || [];
                            this.affectedAirports = event.affectedLocations.filter(a => a.type == AffectedLocationType.Airport) || [];
                            this.affectedSeaports = event.affectedLocations.filter(a => a.type == AffectedLocationType.Seaport) || [];

                            this.images = event.details.images || [];
                            this.attachments = event.details.attachments || [];
                            this.sources = event.details.sources || [];

                            this.eventFormGroup.patchValue({
                                details: {
                                    startDate: this.getDate(new Date(event.details.startDate))
                                }
                            });
                            console.log('this.eventFormGroup');
                            console.log(this.eventFormGroup);

                        });
                } else {
                    this._eventService.getEvent(this.eventId)
                        .subscribe(event => {
                            console.log(event);
                            if (event.details.status === Status.Closed ||
                                event.details.status === Status.InActive ||
                                (event.details.status === Status.Contained && event.details.statusPercentage === 100)) {
                                this._route.navigate(['/events']);
                            }
                        });
                }
            }
            else {
                this._eventService.getEvent(this.eventId)
                    .subscribe(event => {
                        console.log(event);
                        //if (event.details.status === Status.Closed ||
                        //    event.details.status === Status.InActive ||
                        //    (event.details.status === Status.Contained && event.details.statusPercentage === 100)) {
                        //    this._route.navigate(['/events']);
                        //}

                        this.eventTypes = this.categories.find(c => c.id == event.details.category.id).eventTypes;

                        console.log('event.details.category.id');
                        console.log(event.details.category.id);
                        console.log('event.details.category');
                        console.log(event.details.category);
                        console.log(this.eventTypes);
                        if (event.associatedEvent.category) {
                            this.associatedEventTypes = this.categories && this.categories.find(c => c.id == event.associatedEvent.category.id).eventTypes || null;
                        }

                        this.onSelectCountry(event.place.country.countryId);
                        if(event.place.state){
                        this.onSelectState(event.place.state.stateId);
                        }

                        this.images = event.details.images || [];
                        this.attachments = event.details.attachments || [];
                        this.sources = event.details.sources || [];

                        this.eventFormGroup.patchValue(event);

                        this.affectedLocations = event.affectedLocations || [];
                        this.affectedSuppliers = event.affectedLocations.filter(a => a.type == AffectedLocationType.Company) || [];
                        this.affectedAirports = event.affectedLocations.filter(a => a.type == AffectedLocationType.Airport) || [];
                        this.affectedSeaports = event.affectedLocations.filter(a => a.type == AffectedLocationType.Seaport) || [];

                        // let date = new Date(event.details.startDate);
                        this.eventFormGroup.patchValue({
                            details: {
                                startDate: this.getDate(new Date(event.details.startDate))
                            }
                        });

                        console.log('this.eventFormGroup');
                        console.log(this.eventFormGroup);
                    });
            }
        }
    }
    getDate(date: Date) {
        //  let date:Date = new Date(dateStr)
        return {
            date: {
                year: date.getFullYear(),
                month: date.getMonth() + 1,
                day: date.getDate()
            }
        };
    }
    setDate(fullDate: CustomDate) {
        return new Date(fullDate.date.year, fullDate.date.month - 1, fullDate.date.day + 1);
    }
    onSelectAssociatedCategory(categoryId) {
        if (categoryId != -1) {
            this.associatedEventTypes = this.categories && this.categories.find(p => p.id == categoryId).eventTypes || null;
        }
        else {
            this.associatedEventTypes = [];
        }
    }
    onSelectCategory(categoryId) {
        if (categoryId != -1) {
            this.eventTypes = this.categories && this.categories.find(p => p.id == categoryId).eventTypes || [];
        }
        else {
            this.eventTypes = [];
        }
    }

    onSelectCountry(countryId) {
        if (countryId != -1) {
            this._stateService.getStates(countryId)
                .subscribe(p => {
                    this.States = p || [];
                });
        }
    }

    onSelectState(stateId) {
        if (stateId != -1) {
            this._cityService.getCities(stateId)
                .subscribe(p => {
                    this.cities = p || [];
                });
        }
    }
    onAffectedClick() {
        // original Event
        let originalAffected = this.eventFormGroup.get('effectRange.affectedRadius').value || 0;
        let originalNear = this.eventFormGroup.get('effectRange.nearRadius').value || 0;
        let originallat = this.eventFormGroup.get('effectRange.location.coordinates').value[0] || 0;
        let originallong = this.eventFormGroup.get('effectRange.location.coordinates').value[1] || 0;
        let originalCategoryId = this.eventFormGroup.get('details.category').value.id || 0;
        let originalTypeId = this.eventFormGroup.get('details.type').value.id || 0;

        // associated Event
        let associatedAffected = this.eventFormGroup.get('associatedEvent.effectRange.affectedRadius').value || originalAffected;
        let associatedNear = this.eventFormGroup.get('associatedEvent.effectRange.nearRadius').value || originalNear;
        let associatedlat = this.eventFormGroup.get('associatedEvent.effectRange.location.coordinates').value[0] || originallat;
        let associatedlong = this.eventFormGroup.get('associatedEvent.effectRange.location.coordinates').value[1] || originallong;
        let associatedCategoryId = this.eventFormGroup.get('associatedEvent.category').value.id;
        let associatedTypeId = this.eventFormGroup.get('associatedEvent.type').value.id;
        console.log(associatedAffected, associatedNear, associatedlat, associatedlong, associatedCategoryId, associatedTypeId);

        if (originalAffected > originalNear || associatedAffected > associatedNear) {
            alert("Affected range can't be greater than near range.");
            return;
        }


        let cat = this.categories && this.categories.find(e => e.id === originalCategoryId) || null;
        if (!cat) return;
        let originalType = cat.eventTypes && cat.eventTypes.find(e => e.id === originalTypeId) || null;
        if (!originalType) return;
        this.isLoadingData = true;
        this._affectedService.getAffectedLocation(originallat, originallong, originalAffected, originalNear)
            .subscribe(locations => {
                this.affectedLocations = [];
                for (let location of locations) {
                    location.disasterTypes = [];
                    location.disasterTypes.push(originalType);
                    this.affectedLocations.push(location);
                }
                this.isLoadingData = false;
                console.log(this.affectedLocations);

                // associated Event
                if ((associatedAffected != '' || associatedNear != '') &&
                    associatedlat !== '' &&
                    associatedlong !== '' &&
                    associatedCategoryId != -1 &&
                    associatedTypeId != -1) {

                    this.isLoadingData = true;
                    console.log("associated");
                    let associatedCat = this.categories && this.categories.find(e => e.id === associatedCategoryId) || null;
                    let associatedType = associatedCat && associatedCat.eventTypes && associatedCat.eventTypes.find(e => e.id === associatedTypeId) || null;
                    this._affectedService
                        .getAffectedLocation(associatedlat, associatedlong, associatedAffected, associatedNear)
                        .subscribe(locations => {
                            for (let location of locations) {
                                let existing = this.affectedLocations && this.affectedLocations.find(i => i.locationId == location.locationId && i.type == location.type) || null;
                                if (existing != null) {
                                    console.log("existing");
                                    existing.disasterTypes.push(associatedType);
                                } else {
                                    location.disasterTypes = [];
                                    location.disasterTypes.push(associatedType);
                                    this.affectedLocations.push(location);
                                }
                            }
                            console.log(this.affectedLocations);
                            this.fillCollections();
                            this.isLoadingData = false;
                        });
                } else {
                    this.fillCollections();
                }
            });


    }
    fillCollections() {
        this.affectedSuppliers = this.affectedLocations.filter(p => p.type == AffectedLocationType.Company) || [];
        this.affectedAirports = this.affectedLocations.filter(p => p.type == AffectedLocationType.Airport) || [];
        this.affectedSeaports = this.affectedLocations.filter(p => p.type == AffectedLocationType.Seaport) || [];
    }

    initEventGroup() {
        this.eventFormGroup = this._fb.group({
            // code: ['', [Validators.required, Validators.minLength(10)]],
            details: this._formGroupService.initDetails(),
            features: this._formGroupService.initFeatures(),
            place: this._formGroupService.initPlace(),
            effectRange: this._formGroupService.initEffectRange(),
            associatedEvent: this._formGroupService.initAssociatedEvent(),
            // affectedLocations: this._fb.array([
            //   this._formGroupService.initAffectedLocation()
            // ]),
            isAlert: [false, Validators.required]
        });

        this.eventFormGroup.get('associatedEvent').get('category').valueChanges.subscribe(
            (category: number) => {
                if (category != -1) {
                    this.eventFormGroup.get('associatedEvent').get('categoryStatus').setValidators([Validators.required]);
                }
                this.eventFormGroup.get('associatedEvent').get('categoryStatus').updateValueAndValidity();
            }
        );
    }

    isFormValid(): boolean {
        this.validationSummary = "";
        if (!this.eventFormGroup.valid) {
            this.validationSummary += "Error. Required Field(s) Missing. \n";
        }

        let originalAffected = this.eventFormGroup.get('effectRange.affectedRadius').value || 0;
        let originalNear = this.eventFormGroup.get('effectRange.nearRadius').value || 0;
        let associatedAffected = this.eventFormGroup.get('associatedEvent.effectRange.affectedRadius').value || originalAffected;
        let associatedNear = this.eventFormGroup.get('associatedEvent.effectRange.nearRadius').value || originalNear;
        if (originalAffected > originalNear || associatedAffected > associatedNear) {
            this.validationSummary += "Affected range can't be greater than near range. \n";
        }
        console.log(this.sources);
        if (this.sources && this.sources.length === 0) {
            this.validationSummary += "You must include at least one source. \n";
        }
        if (this.images && this.images.length === 0) {
            this.validationSummary += "You must include at least one image. \n";
        }
        // if (this.associatedEventTypes && this.associatedEventTypes.length > 0) {
        if (this.eventFormGroup.get('associatedEvent.category.id').value != -1) {
            let associatedAffected = this.eventFormGroup.get('associatedEvent.effectRange.affectedRadius').value;
            let associatedNear = this.eventFormGroup.get('associatedEvent.effectRange.nearRadius').value;
            let associatedTypeId = this.eventFormGroup.get('associatedEvent.type').value.id;
            let associatedseverityId = this.eventFormGroup.get('associatedEvent.severity').value;
            let associatedstatusId = this.eventFormGroup.get('associatedEvent.categoryStatus').value;
            if (associatedAffected == '' || associatedNear == '' || associatedTypeId == -1 || associatedseverityId == -1 || associatedstatusId == -1) {
                this.validationSummary += "Associated event Data Required. \n";
            }
        }

        return this.validationSummary === "";
    }


    public onFormSubmit(eventFormModel) {
        console.log(eventFormModel);
        if (this.isFormValid()) {
            this.event = <Event>eventFormModel;
            // Object.assign({},this.event,eventFormModel);
            this.fillEventMisedData();
            console.log(this.event.place.country);
            if (this.eventId) {

                this.event.id = this.eventId;

                if (this.isUpdate) {

                    if (this.subIndex) {
                        //update sub
                        this._eventService.updateSubEvent(this.eventId, this.subIndex, this.event)
                            .subscribe(res => {
                                this._route.navigate(['/events']);
                            });

                    } else {
                        //add sub
                        this._eventService.addSubEvent(this.eventId, this.event)
                            .subscribe(res => {
                                this._route.navigate(['/events']);
                            });

                    }
                } else {
                    //update event
                    console.log("event:");
                    console.log(this.event);
                    this._eventService.updateEvent(this.event)
                        .subscribe(res => {
                            this._route.navigate(['/events']);
                        });
                }
            } else {
                //add event
                this._eventService.addEvent(this.event)
                    .subscribe(res => {
                        this._route.navigate(['/events']);
                    });
            }
        } else {
            alert(this.validationSummary);
        }
    }
    fillEventMisedData() {

        this.event.place.country = this.countries && this.countries.find(e => e.countryId == this.event.place.country.countryId);

        this.event.place.state = this.States && this.States.find(e => e.stateId == this.event.place.state.stateId);
        this.event.place.city = this.cities && this.cities.find(e => e.cityId == this.event.place.city.cityId);

        let cat = this.categories && this.categories.find(e => e.id === this.event.details.category.id);
        this.event.details.category = { id: cat.id, name: cat.name };
        this.event.details.type = cat.eventTypes && cat.eventTypes.find(e => e.id === this.event.details.type.id);

        let associatedCat = this.categories && this.categories.find(e => e.id === this.event.associatedEvent.category.id)
        // console.log('associatedCat.id');
        // console.log(associatedCat.id);
        if (associatedCat&&associatedCat.id!=-1) {
            this.event.associatedEvent.category = { id: associatedCat.id, name: associatedCat.name };
            this.event.associatedEvent.type = associatedCat.eventTypes.find(e => e.id === this.event.associatedEvent.type.id);
        }
        if(this.event.associatedEvent.severity==-1){
            this.event.associatedEvent.severity=null;
        }
        
        if(this.event.associatedEvent.categoryStatus==-1){
            this.event.associatedEvent.categoryStatus=null;
        }
        

        let affectedLocations = [...this.affectedSuppliers || [], ...this.affectedAirports || [], ...this.affectedSeaports || []];
        this.event.affectedLocations = affectedLocations;
        let strtDate: any = Object.assign({}, this.event.details.startDate);

        console.log("'this.eventFormGroup.get('details.startDate').value'");
        console.log(this.eventFormGroup.get('details.startDate').value);
        this.event.details.startDate = this.setDate(this.eventFormGroup.get('details.startDate').value);

        this.event.details.images = this.images || [];
        this.event.details.attachments = this.attachments || [];
        this.event.details.sources = this.sources || [];

    }
    isFieldValid(field: string) {
        return !this.eventFormGroup.get(field).valid || this.eventFormGroup.get(field).value == -1;
        // return !this.eventFormGroup.get(field).valid && this.eventFormGroup.get(field).touched;
    }
    getAffectedStatus(field: number) {
        if (field === 0) {
            return "Affected";
        }
        else {
            return "Near";

        }
        // return !this.eventFormGroup.get(field).valid && this.eventFormGroup.get(field).touched;
    }
    confirmSuppliers(id, e) {
        let status: boolean = e.target.checked;
        let index = this.affectedSuppliers.findIndex(l => l.locationId == id);
        this.affectedSuppliers[index].isConfirmed = status;
        console.log(this.affectedSuppliers[index]);
    }
    confirmSeaports(id, e) {
        let status: boolean = e.target.checked;
        let index = this.affectedSeaports.findIndex(l => l.locationId == id);
        this.affectedSeaports[index].isConfirmed = status;
        console.log(this.affectedSeaports[index]);
    }
    confirmAirports(id, e) {
        let status: boolean = e.target.checked;
        let index = this.affectedAirports.findIndex(l => l.locationId == id);
        this.affectedAirports[index].isConfirmed = status;
        console.log(this.affectedAirports[index]);
    }

    //images
    removefile(idx, isImage) {

        if (idx !== -1) {
            if (isImage) {
                this.images.splice(idx, 1);
            } else {
                this.attachments.splice(idx, 1);
            }
        }
    }
    addSource(sourceUrl, sourceName) {
        if (sourceUrl && sourceName) {
            console.log({ url: sourceUrl, name: sourceName });
            this.sources = this.sources || [];
            this.sources.push({ url: sourceUrl, name: sourceName });
        }
    }

    fileChangeEvent(fileInput: any, isImages) {
        let files = <Array<File>>fileInput.target.files;
        if (files.length == 0) {
            alert('Please select at least 1 file to upload!');
        }
        else {
            this.isLoadingData = true;

            let formData: FormData = new FormData();

            for (let i = 0; i < files.length; i++) {
                formData.append('uploadedFiles', files[i], files[i].name);
            }

            let apiUrl = "/api/file/PostExcel";

            this._fileService.uploadFiles(formData)
                .subscribe(res => {
                    if (isImages) {
                        this.images = [...this.images || [], ...res || []];
                    } else {
                        this.attachments = [...this.attachments || [], ...res || []];
                    }
                    this.isLoadingData = false;
                });
        }
    }

    fileChangeImporter(fileInput: any, isImages) {
        let files = <Array<File>>fileInput.target.files;
        if (files.length == 0) {
            alert('Please select at least 1 file to upload!');
        }
        else {
            this.isLoadingData = true;

            let formData: FormData = new FormData();

            for (let i = 0; i < files.length; i++) {
                formData.append('uploadedFiles', files[i], files[i].name);
            };

            this._fileService.importExcel(ImportType.Seaport, formData)
                .subscribe(res => {
                    this.attachments = [...this.attachments || [], ...res || []];
                    this.isLoadingData = false;
                });
        }
    }
}