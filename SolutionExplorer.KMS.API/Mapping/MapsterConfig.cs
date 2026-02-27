using Mapster;
using SolutionExplorer.KMS.Application.Utilities;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Dtos.AAA;
using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Domain.Entities.AAA;

namespace SolutionExplorer.KMS.API.Mapping
{
    public static class MapsterConfig
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig<UserRole, UserRoleDisplayDto>
                .NewConfig()
                .Map
                (
                    destination => destination.RoleTitle,
                    source => source.Role == null ? string.Empty : source.Role.Title
                )
                ;

            TypeAdapterConfig<User, UserDisplayDto>
                .NewConfig()
                .Map
                (
                    destination => destination.ProfileAttachmentUrl,
                    source => source.Profile != null ? $"/staticfiles/{source.Profile.FileName}" : ""
                )
                .Map
                (
                    destination => destination.SignatureAttachmentUrl,
                    source => source.Signature != null ? $"/staticfiles/{source.Signature.FileName}" : ""
                )
                ;

            TypeAdapterConfig<Personnel, PersonnelDisplayDto>
                .NewConfig()
                .Map
                (
                    destination => destination.ProfileAttachmentUrl,
                    source => source.Profile != null ? $"/staticfiles/{source.Profile.FileName}" : ""
                )
                .Map
                (
                    destination => destination.SignatureAttachmentUrl,
                    source => source.Signature != null ? $"/staticfiles/{source.Signature.FileName}" : ""
                )
                .Map
                (
                    destination => destination.SuccessorUserFullName,
                    source => source.SuccessorUser != null ? $"{source.SuccessorUser.FirstName ?? ""} {source.SuccessorUser.LastName ?? ""}".Trim() : ""
                )
                .Map
                (
                    destination => destination.FirstConfirmerUserFullName,
                    source => source.FirstConfirmerUser != null ? $"{source.FirstConfirmerUser.FirstName ?? ""} {source.FirstConfirmerUser.LastName ?? ""}".Trim() : ""
                )
                .Map
                (
                    destination => destination.SecondConfirmerUserFullName,
                    source => source.SecondConfirmerUser != null ? $"{source.SecondConfirmerUser.FirstName ?? ""} {source.SecondConfirmerUser.LastName ?? ""}".Trim() : ""
                )
                .Map
                (
                    destination => destination.RoleIds,
                    source => source.UserRoles != null ? source.UserRoles.Select(x => x.RoleId).ToList() : null
                )
                ;

            TypeAdapterConfig<PersonnelColorBlindnessTest, PersonnelColorBlindnessTestDisplayDto>
                .NewConfig()
                .Map
                (
                    destination => destination.FirstConfirmerUserFullName,
                    source => $"{source.FirstConfirmerUser.FirstName ?? ""} {source.FirstConfirmerUser.LastName ?? ""}".Trim()
                )
                .Map
                (
                    destination => destination.SecondConfirmerUserFullName,
                    source => $"{source.SecondConfirmerUser.FirstName ?? ""} {source.SecondConfirmerUser.LastName ?? ""}".Trim()
                )
                .Map
                (
                    destination => destination.PersonnelFullName,
                    source => source.Personnel != null ? $"{source.Personnel.FirstName ?? ""} {source.Personnel.LastName ?? ""}".Trim() : ""
                )
                .Map
                (
                    destination => destination.Prefix,
                    source => source.Personnel.Prefix
                )
                .Map
                (
                    destination => destination.PersonnelNumber,
                    source => source.Personnel.PersonnelNumber
                )
                .Map
                (
                    destination => destination.EmploymentDate,
                    source => source.Personnel.EmploymentDate
                )
                ;

            TypeAdapterConfig<PersonnelTrainingCourse, PersonnelTrainingCourseDisplayDto>
                .NewConfig()
                .Map
                (
                    destination => destination.FirstConfirmerUserFullName,
                    source => $"{source.FirstConfirmerUser.FirstName ?? ""} {source.FirstConfirmerUser.LastName ?? ""}".Trim()
                )
                .Map
                (
                    destination => destination.SecondConfirmerUserFullName,
                    source => $"{source.SecondConfirmerUser.FirstName ?? ""} {source.SecondConfirmerUser.LastName ?? ""}".Trim()
                )
                .Map
                (
                    destination => destination.PersonnelFullName,
                    source => source.Personnel != null ? $"{source.Personnel.FirstName ?? ""} {source.Personnel.LastName ?? ""}".Trim() : ""
                )
                .Map
                (
                    destination => destination.PersonnelNumber,
                    source => source.Personnel.PersonnelNumber
                )
                ;

            TypeAdapterConfig<Identifier, IdentifierDisplayDto>
                .NewConfig()
                .Map
                (
                    destination => destination.ProducerUserFullName,
                    source => source.ProducerUser != null ? $"{source.ProducerUser.FirstName ?? ""} {source.ProducerUser.LastName ?? ""}".Trim() : ""
                )
                .Map
                (
                    destination => destination.FirstConfirmerUserFullName,
                    source => $"{source.FirstConfirmerUser.FirstName ?? ""} {source.FirstConfirmerUser.LastName ?? ""}".Trim()
                )
                .Map
                (
                    destination => destination.SecondConfirmerUserFullName,
                    source => $"{source.SecondConfirmerUser.FirstName ?? ""} {source.SecondConfirmerUser.LastName ?? ""}".Trim()
                )
                .Map
                (
                    destination => destination.AttachmentFileName,
                    source => (source.AttachmentFile != null ? source.AttachmentFile.FileName : "").Trim()
                )
                ;

            TypeAdapterConfig<Equipment, EquipmentDisplayDto>
                .NewConfig()
                .Map
                (
                    destination => destination.FirstConfirmerUserFullName,
                    source => $"{source.FirstConfirmerUser.FirstName ?? ""} {source.FirstConfirmerUser.LastName ?? ""}".Trim()
                )
                .Map
                (
                    destination => destination.SecondConfirmerUserFullName,
                    source => $"{source.SecondConfirmerUser.FirstName ?? ""} {source.SecondConfirmerUser.LastName ?? ""}".Trim()
                )
                ;

            TypeAdapterConfig<Experiment, ExperimentDisplayDto>
                .NewConfig()
                .Map
                (
                    destination => destination.FirstConfirmerUserFullName,
                    source => $"{source.FirstConfirmerUser.FirstName ?? ""} {source.FirstConfirmerUser.LastName ?? ""}".Trim()
                )
                .Map
                (
                    destination => destination.SecondConfirmerUserFullName,
                    source => $"{source.SecondConfirmerUser.FirstName ?? ""} {source.SecondConfirmerUser.LastName ?? ""}".Trim()
                )
                ;

            TypeAdapterConfig<LabReportHistory, LabReportHistoryDisplayDto>
                .NewConfig()
                .Map
                (
                    destination => destination.ReporterUserFullName,
                    source => $"{source.ReporterUser.FirstName ?? ""} {source.ReporterUser.LastName ?? ""}".Trim()
                )
                .Map
                (
                    destination => destination.ReceiverUserFullName,
                    source => source.ReceiverUser != null ? $"{source.ReceiverUser.FirstName ?? ""} {source.ReceiverUser.LastName ?? ""}".Trim() : string.Empty
                )
                .Map
                (
                    destination => destination.FirstConfirmerUserFullName,
                    source => $"{source.FirstConfirmerUser.FirstName ?? ""} {source.FirstConfirmerUser.LastName ?? ""}".Trim()
                )
                .Map
                (
                    destination => destination.SecondConfirmerUserFullName,
                    source => $"{source.SecondConfirmerUser.FirstName ?? ""} {source.SecondConfirmerUser.LastName ?? ""}".Trim()
                )
                ;

            TypeAdapterConfig<Reference, ReferenceDisplayDto>
                .NewConfig()
                .Map
                (
                    destination => destination.AttachmentFileName,
                    source => (source.AttachmentFile != null ? source.AttachmentFile.FileName : "").Trim()
                )
                ;

            TypeAdapterConfig<QualityControl, QualityControlDisplayDto>
                .NewConfig()
                .Map
                (
                    destination => destination.FirstConfirmerUserFullName,
                    source => $"{source.FirstConfirmerUser.FirstName ?? ""} {source.FirstConfirmerUser.LastName ?? ""}".Trim()
                )
                .Map
                (
                    destination => destination.SecondConfirmerUserFullName,
                    source => $"{source.SecondConfirmerUser.FirstName ?? ""} {source.SecondConfirmerUser.LastName ?? ""}".Trim()
                )
                .Map
                (
                    destination => destination.PerformedByUserFullName,
                    source => source.PerformedByUser != null ? $"{source.PerformedByUser.FirstName ?? ""} {source.SecondConfirmerUser.LastName ?? ""}".Trim() : string.Empty
                )
                .Map
                (
                    destination => destination.StorageConditionTitle,
                    source => source.StorageCondition.Title
                )
                //.Map
                //(
                //    destination => destination.PhysicalSpecificationText,
                //    source => (source.PhysicalSpecifications != null && source.PhysicalSpecifications.Any(x => x.IsChecked))
                //        ? string.Join(", ", source.PhysicalSpecifications.Where(x=>x.IsChecked).Select(x=>x.QCBaseInfoPhysicalSpecification.Title).ToList())
                //        : string.Empty
                //)
                ;

            TypeAdapterConfig<PeriodicQualityControl, PeriodicQualityControlDisplayDto>
                .NewConfig()
                .Map
                (
                    destination => destination.FirstConfirmerUserFullName,
                    source => source.FirstConfirmerUser != null ? $"{source.FirstConfirmerUser.FirstName ?? ""} {source.FirstConfirmerUser.LastName ?? ""}".Trim() : string.Empty
                )
                .Map
                (
                    destination => destination.SecondConfirmerUserFullName,
                    source => source.SecondConfirmerUser != null ? $"{source.SecondConfirmerUser.FirstName ?? ""} {source.SecondConfirmerUser.LastName ?? ""}".Trim() : string.Empty
                )
                .Map
                (
                    destination => destination.PerformedByUserFullName,
                    source => source.PerformedByUser != null ? $"{source.PerformedByUser.FirstName ?? ""} {source.SecondConfirmerUser.LastName ?? ""}".Trim() : string.Empty
                )
                //.Map
                //(
                //    destination => destination.Appearances,
                //    source => source.Appearances != null && source.Appearances.Any()
                //        ? source.Appearances.Select(x => new PeriodicQCAppearanceDisplayDto()
                //        {
                //            QCBaseInfoAppearanceId = x.QCBaseInfoAppearanceId,
                //            AppearanceGroup = x.QCBaseInfoAppearance.AppearanceGroup,
                //            Title = x.QCBaseInfoAppearance.Title,
                //            IsSelected = x.QCBaseInfoAppearance.IsSelected,
                //        })
                //        .ToList()
                //        : null
                //)
                //.Map
                //(
                //    destination => destination.PhysicalSpecifications,
                //    source => source.PhysicalSpecifications != null && source.PhysicalSpecifications.Any()
                //        ? source.PhysicalSpecifications.Select(x => new PeriodicQCPhysicalSpecificationsDisplayDto()
                //        {
                //            QCBaseInfoPhysicalSpecificationId = x.QCBaseInfoPhysicalSpecificationId,
                //            Title = x.QCBaseInfoPhysicalSpecification.Title,
                //            IsChecked = x.IsChecked
                //        })
                //        .ToList()
                //        : null
                //)
                ;


            TypeAdapterConfig<PhysicalSpecification, PhysicalSpecificationDisplayDto>
                .NewConfig()
                .Map
                (
                    destination => destination.QCBaseInfoPhysicalSpecificationTitle,
                    source => source.QCBaseInfoPhysicalSpecification != null ? source.QCBaseInfoPhysicalSpecification.Title : string.Empty
                )
                ;

        }
    }
}
