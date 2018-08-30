declare module server {
	/** Base class for entities */
	interface BaseEntity {
		/** Gets or sets the entity identifier */
		id: any;
	}
	interface BaseEmbeddedEntity {
		id: string;
	}
}
