import { AuditEntity } from '../../shared/auditentity';
import { Place } from '../../events/meta-models/Place';
import { EventDetails } from '../../events/meta-models/event-details';
import { EventFeature } from '../../events/meta-models/event-feature';
import { EffectRange } from '../../events/meta-models/effect-range';
import { AssociatedEvent } from '../../events/meta-models/associated-event';
import { AffectedLocation } from '../../events/meta-models/affected-location';
export interface Event extends AuditEntity {
		code: string;
		place: Place;
		details: EventDetails;
		features: EventFeature;
		effectRange: EffectRange;
		associatedEvent: AssociatedEvent;
		affectedLocations: AffectedLocation[];
		isAlert: boolean;
		updates: any[];
}
