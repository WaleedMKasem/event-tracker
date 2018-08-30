import { Lookup } from '../../lookups/lookup';
import { Severity } from '../../shared/enums/severity';
import { Status } from '../../shared/enums/status';
export interface AssociatedEvent {
		category: Lookup;
		type: Lookup;
		severity: Severity;
		effectRange: {
			affectedRadius?: number;
			nearRadius?: number;
			location: Location;
        };
        categoryStatus: Status;
}
