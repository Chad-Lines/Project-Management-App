using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Reports
{
    internal class Reports
    {
        
        private static List<Models.Issue> IssuesByTargetResolutionDate()
        {
            // Issues ordered by target resolution date
            return new List<Models.Issue>();
        }
        
        private static int IssueResolvedByMonthCount()
        {
            // Issues (Count) resolved by month
            return 0;
        }

        private static List<Models.Issue> IssuesResolvedByMonth(DateTime? month)
        {
            // Issues (List) resolved by month

            // If there is no month provided, then we do it for ALL months
            if (month == null)
            {

            }
            // If a month IS provided, then we return only those for that specific month
            else
            {

            }

            return new List<Models.Issue>();
        }

        private static List<Models.Project> ProjectCompletedByMonth(DateTime? month)
        {
            // Projects (List) completed by month

            // If there is no month provided, then we do it for ALL months
            if (month == null)
            {

            }
            // If a month IS provided, then we return only those for that specific month
            else
            {

            }

            return new List<Models.Project>();
        }
    }
}
