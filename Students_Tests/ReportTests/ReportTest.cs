﻿using NUnit.Framework;
using Students.Enums;
using Students.Objects;
using Students.Reports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Students_Tests.ReportTests
{
    public class ReportTest
    {
        private string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentsDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        /// <summary>
        /// The method tests the method generation session result report by group.
        /// </summary>
        [Test]
        public void GenerateSessionReport_GenerationSessionResultReportByGroup_GenerationSessionResultReportByGroup()
        {
            string path = @"Report1.xlsx";
            int sessionNumber = 1;
            int sortableSheet = 2;
            GenerationReport generationReport = new GenerationReport(_connectionString);
            generationReport.GenerationSessionResultReportByGroup(sessionNumber, path, sortableSheet, SortOrder.Ascending);

            long result;
            using (var reader = new FileStream(path, FileMode.Open))
            {
                result = reader.Length;
            }

            Assert.IsTrue(result != 0);
        }

        /// <summary>
        /// The method tests the method generation result summary table by group.
        /// </summary>
        [Test]
        public void GenerateSessionReport_GenerationResultSummaryTableByGroups_GenerationResultSummaryTableByGroup()
        {
            string path = @"Report2.xlsx";
            int sessionNumber = 1;
            int sortableSheet = 2;
            GenerationReport generationReport = new GenerationReport(_connectionString);
            generationReport.GenerationResultSummaryTableByGroup(path, sortableSheet, SortOrder.Ascending);

            long result;
            using (var reader = new FileStream(path, FileMode.Open))
            {
                result = reader.Length;
            }

            Assert.IsTrue(result != 0);
        }

        /// <summary>
        /// The method tests the method generation bad student by group.
        /// </summary>
        [Test]
        public void GenerateSessionReport_GenerationGenerationBadStudentByGroup_GenerationBadStudentByGroup()
        {
            string path = @"Report3.xlsx";
            int sortableSheet = 2;
            GenerationReport generationReport = new GenerationReport(_connectionString);
            generationReport.GenerationBadStudentByGroup(path, sortableSheet, SortOrder.Ascending);

            long result;
            using (var reader = new FileStream(path, FileMode.Open))
            {
                result = reader.Length;
            }

            Assert.IsTrue(result != 0);
        }

    }
}
