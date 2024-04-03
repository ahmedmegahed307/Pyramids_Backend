using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramids.Core.Models.AI
{
    public static class AIChatMessages
    {
        #region Text Classification Messages
        public static string ClassifyMessageInstruction => "Analyze the user's input and classify it into one of the following categories:\n\n" +
                                  "1.category: To log/create a job/call for a client,look for phrases which has the main purpose of the following:\n" +
                                      "-look for phrases similar to:" +
                                      "-'Assign a 3-hour call for ClientName'" +
                                      "-'Create/log a job/call for ClientName" +
                                      "-assign a job for emre to fix a problem for ClientName" +

                                  "2.category: To request jobs report, user will provide parameters such as,(datefrom,dateto,jobtype,subtype,status,priority,client,sites)" +
                                      "-Show jobs report for ClientName in the last month." +
                                      "-Show me jobs for ClientName" +
                                      "-I need report for red fire jobs" +
                                      "-I need jobs with jobtype/subtype equal typeName/subName" +
                                      "- show me jobs with status statusName" +
                                      "- show me job with priority priorityName" +
                                      "show me clientname jobs report against sites names" +
                                  "\n" +
                                  "Return 1(int) if the input falls into the first category or 2(int) for the second category. or 0(int) if couldn't detect category";

        public static string ClassifyMessageOnFail => "We couldn't determine your intent. Please try a different text or consider using keywords for more accurate results.";

        #endregion

        #region Create Job Messages

        public static string CreateJobInstruction =>
          "we are a field service company and I need to log a call/job for a client. from the sentence provided to you," +
              " you will Provide me as a JSON object with the following info,and if a value is not provided just provide null" +
              "1- ClientName(string)" +
              "2- SiteName(string)" +
              "3- JobTypeName(string)" +
              "4- JobSubTypeName(string)" +
              "5- EngineerName(string)" +
              "6- JobDate(datetime)" +
              "7- EstimatedDuration(int) if provided in hours convert it to minutes" +
              "8- IssueDescription(string)" +
              "9- Description( IssueDescription || general explaination of the job to be logged || (Job Logged With AI) )";
        public static string CheckCreateJobInfoByAIFail => "We couldn't process your request for logging a job. Please ensure you've entered the client's name correctly.";

        #endregion


        #region Job Query Report Messages
        public static string JobReportInstructions =>
         "we are a field service company and I need to get a report contains list of jobs according to" +
         "some parameters(datefrom,dateto,jobtype,subtype,status,priority,client,sites). From the sentence provided to you," +
          "you will Provide me as a JSON object with the following info,and if a value is not provided just provide null " +
          "1- DateFrom(datetime)" +
          "2- DateTo(datetime)" +
          "3-ClientName(string)" +
          "4- JobTypeName(string)" +
          "5- JobSubTypeName(string)" +
          "6-JobPriorityName(string)" +
          "7- JobStatusName(string)" +
          "8- IssueDescription(string)" +
          "9- Description(equal IssueDescription or general explanation of the job to be logged)";
        public static string JobQueryReportByAIFail => "We couldn't process your request for job query. Please ensure you've entered text correctly";
        #endregion

    }

}
