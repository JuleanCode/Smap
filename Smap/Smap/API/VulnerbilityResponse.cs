using System;
using System.Collections.Generic;
using System.Text;

namespace Smap.API
{
    public class CVEDataMeta
    {
        public string ID { get; set; }
        public string ASSIGNER { get; set; }
    }

    //public class Description
    //{
    //    public string lang { get; set; }
    //    public string value { get; set; }
    //}

    //public class ProblemtypeData
    //{
    //    public IList<Description> description { get; set; }
    //}

    //public class Problemtype
    //{
    //    public IList<ProblemtypeData> problemtype_data { get; set; }
    //}

    public class ReferenceData
    {
        public string url { get; set; }
        public string name { get; set; }
        public string refsource { get; set; }
        public IList<string> tags { get; set; }
    }

    public class References
    {
        public IList<ReferenceData> reference_data { get; set; }
    }

    public class DescriptionData
    {
        public string lang { get; set; }
        public string value { get; set; }
    }

    public class Description
    {
        public IList<DescriptionData> description_data { get; set; }
    }

    public class Cve
    {
        public string data_type { get; set; }
        public string data_format { get; set; }
        public string data_version { get; set; }
        public CVEDataMeta CVE_data_meta { get; set; }
        //public Problemtype problemtype { get; set; }
        public References references { get; set; }
        public Description description { get; set; }
    }

    public class CpeMatch
    {
        public bool vulnerable { get; set; }
        public string cpe23Uri { get; set; }
        public IList<object> cpe_name { get; set; }
        public string versionStartIncluding { get; set; }
        public string versionEndIncluding { get; set; }
        public string versionEndExcluding { get; set; }
    }

    //public class Node
    //{
    //    public string operator { get; set; }
    //    public IList<object> children { get; set; }
    //    public IList<CpeMatch> cpe_match { get; set; }
    //}


    //public class Configurations
    //{
    //    public string CVE_data_version { get; set; }
    //    public IList<Node> nodes { get; set; }
    //}

    public class CvssV3
    {
        public string version { get; set; }
        public string vectorString { get; set; }
        public string attackVector { get; set; }
        public string attackComplexity { get; set; }
        public string privilegesRequired { get; set; }
        public string userInteraction { get; set; }
        public string scope { get; set; }
        public string confidentialityImpact { get; set; }
        public string integrityImpact { get; set; }
        public string availabilityImpact { get; set; }
        public double baseScore { get; set; }
        public string baseSeverity { get; set; }
    }

    public class BaseMetricV3
    {
        public CvssV3 cvssV3 { get; set; }
        public double exploitabilityScore { get; set; }
        public double impactScore { get; set; }
    }

    public class CvssV2
    {
        public string version { get; set; }
        public string vectorString { get; set; }
        public string accessVector { get; set; }
        public string accessComplexity { get; set; }
        public string authentication { get; set; }
        public string confidentialityImpact { get; set; }
        public string integrityImpact { get; set; }
        public string availabilityImpact { get; set; }
        public double baseScore { get; set; }
    }

    public class BaseMetricV2
    {
        public CvssV2 cvssV2 { get; set; }
        public string severity { get; set; }
        public double exploitabilityScore { get; set; }
        public double impactScore { get; set; }
        public bool acInsufInfo { get; set; }
        public bool obtainAllPrivilege { get; set; }
        public bool obtainUserPrivilege { get; set; }
        public bool obtainOtherPrivilege { get; set; }
        public bool userInteractionRequired { get; set; }
    }

    public class Impact
    {
        public BaseMetricV3 baseMetricV3 { get; set; }
        public BaseMetricV2 baseMetricV2 { get; set; }
    }

    public class CVEItem
    {
        public Cve cve { get; set; }
        //public Configurations configurations { get; set; }
        public Impact impact { get; set; }
        public string publishedDate { get; set; }
        public string lastModifiedDate { get; set; }
    }

    public class Result
    {
        public string CVE_data_type { get; set; }
        public string CVE_data_format { get; set; }
        public string CVE_data_version { get; set; }
        public string CVE_data_timestamp { get; set; }
        public IList<CVEItem> CVE_Items { get; set; }
    }

    public class VulnerbiltiyResponse
    {
        public int resultsPerPage { get; set; }
        public int startIndex { get; set; }
        public int totalResults { get; set; }
        public Result result { get; set; }
    }
}
