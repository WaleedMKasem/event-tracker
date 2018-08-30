declare module server {
	interface Event extends AuditEntity {
		code: string;
		place: server.Place;
		details: server.EventDetails;
		features: server.EventFeature;
		effectRange: server.EffectRange;
		associatedEvent: server.AssociatedEvent;
		affectedLocations: server.AffectedLocation[];
		isAlert: boolean;
		updates: server.Event[];
	}
}
