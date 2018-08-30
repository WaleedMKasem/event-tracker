declare module server {
	interface AuditEntity extends BaseEntity {
		createdBy?: number;
		createdOn: Date;
		modifiedBy?: number;
		modifiedOn?: Date;
		isDeleted: boolean;
		deletedBy?: number;
		deletedOn?: Date;
	}
}
