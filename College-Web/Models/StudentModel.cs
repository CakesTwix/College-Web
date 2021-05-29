using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace College_Web.Models
{
    public class StudentModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }
        public int Credits { get; set; }
        public int Hours { get; set; }
        public int Assessment { get; set; }
        public string Assessment_EKTC { get; set; }
        public string Note { get; set; }
        public virtual StudentGeneralInfo Info { get; set; }
    }
    public class StudentGeneralInfo
    {
        [Key]
        [ForeignKey("StudentModel")]
        public string ID { get; set; }
        // Collage
        public string CollageUk { get; set; }
        public string CollageEn { get; set; }
        public string OwnershipUk { get; set; }
        public string OwnershipEn { get; set; }
        // Faculty
        public string FacultyUk { get; set; }
        public string FacultyEn { get; set; }
        // EducationFormName
        public string EducationFormNameUk { get; set; }
        public string EducationFormNameEn { get; set; }
        // StudyLanguage
        public string StudyLanguageUk { get; set; }
        public string StudyLanguageEn { get; set; }
        // Qualification 
        public string DegreeUk { get; set; }
        public string DegreeEn { get; set; }
        public string SpecialityUk { get; set; }
        public string SpecialityEn { get; set; }
        public string ProfqualificationUk { get; set; }
        public string ProfqualificationEn { get; set; }
        // FieldofStudy
        public string FieldofStudyUk { get; set; }
        public string FieldofStudyEn { get; set; }
        // LevelofQualification
        public string LevelofQualificationUk { get; set; }
        public string LevelofQualificationEn { get; set; }
        // StudyDuration
        public int years { get; set; }
        public int months { get; set; }
        public string FormNameUk { get; set; }
        public string FormNameEn { get; set; }
        // AccessRequirements
        public string MainUk { get; set; }
        public string MainEn { get; set; }
        public string AdditionalUk { get; set; }
        public string AdditionalEn { get; set; }
        // AccessFurtherStudy
        public string AccessFurtherStudyUk { get; set; }
        public string AccessFurtherStudyEn { get; set; }
        // ProfessionalStatus
        public string ProfessionalStatusUk { get; set; }
        public string ProfessionalStatusEn { get; set; }
        // Sign
        public string PositionUk { get; set; }
        public string PositionEn { get; set; }
        public string SignerNameUk { get; set; }
        public string SignerNameEn { get; set; }
        // Sutisfy
        public string SutisfyUk { get; set; }
        public string SutisfyEn { get; set; }
        // Knowledge 
        public string KnowledgeUk { get; set; }
        public string KnowledgeEn { get; set; }
        // Understanding
        public string UnderstandingUk { get; set; }
        public string UnderstandingEn { get; set; }
        // Judgments
        public string JudgmentsUk { get; set; }
        public string JudgmentsEn { get; set; }
        public virtual StudentModel StudentModel { get; set; }
    }
}
