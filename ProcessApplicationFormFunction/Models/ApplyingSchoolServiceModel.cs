using ProcessApplicationFormFunction.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessApplicationFormFunction.Models
{
    public class ApplyingSchoolServiceModel
    {
        private static string EqualityStatement1 = "That the Secretary of State's decision is unlikely to disproportionately affect any particular person or group who share protected characteristics";
        private static string EqualityStatement2 = "That there are some impacts but on balance the changes will not disproportionately affect any particular person or group who share protected characteristics";

        public string EqualitiesImpactAssessmentDetails { get; set; }
        public StagingApplyingSchool ApplyingSchool { get; set; }

        public ApplyingSchoolServiceModel(StagingApplyingSchool stagingApplyingSchool)
        {
            ApplyingSchool = stagingApplyingSchool;
            EqualitiesImpactAssessmentDetails = ConvertEqualitiesAssessmentDetails(stagingApplyingSchool.SchoolAdEqualitiesImpactAssessment);
        }

        private string ConvertEqualitiesAssessmentDetails(int? selectedStatement) => selectedStatement switch
        {
            907660000 => EqualityStatement1,
            907660001 => EqualityStatement2,
            907660002 => null,
            _ => null
        };
    }
}
