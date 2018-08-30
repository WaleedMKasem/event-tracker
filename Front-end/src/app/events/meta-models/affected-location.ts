import { AffectedLocationType } from '../../shared/enums/affected-locationType';
import { Lookup } from '../../lookups/lookup';
import { Location } from '../../lookups/location';
import { Effect } from '../../shared/enums/effect';

export interface AffectedLocation {
    locationId: any;
    name: string;
    location: Location;
    type: AffectedLocationType;
    locationType: string;
    iata: string;
    locode: string;
    disasterTypes: Lookup[];
    distance: number;
    associatedDistance?: number;
    status: Effect;
    isConfirmed: boolean;
}
