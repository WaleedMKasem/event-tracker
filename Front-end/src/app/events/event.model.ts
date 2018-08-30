import { AuditEntity } from "../shared/audit-entity.model";

import { Place } from '../events/meta-models/place';
import { EventDetails } from '../events/meta-models/event-Details';
import { EventFeature } from '../events/meta-models/event-Feature';
import { EffectRange } from '../events/meta-models/effect-range';
import { AssociatedEvent } from '../events/meta-models/associated-Event';
import { AffectedLocation } from '../events/meta-models/affected-Location';

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
