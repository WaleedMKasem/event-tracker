import { BaseEntity } from '../shared/baseEntity';
import { Lookup } from '../lookups/lookup';
import { Country } from '../lookups/country';
import { City } from '../lookups/city';

export interface Seaport extends BaseEntity {
    /** public int PortId { get; set; } */
    name: string;
    type: Lookup;
    place: {
        country: Country;
        state: {
            stateId: number;
            name: string;
        };
        city: City;
        other: string;
    };
    location: Location;
    loCode: string;
}
