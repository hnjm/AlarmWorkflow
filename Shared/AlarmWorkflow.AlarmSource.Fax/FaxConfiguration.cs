﻿using System;
using System.Collections.Generic;
using System.Xml.Linq;
using AlarmWorkflow.Shared.Core;
using AlarmWorkflow.Shared.Settings;

namespace AlarmWorkflow.AlarmSource.Fax
{
    /// <summary>
    /// Represents the current configuration. Wraps the SettingsManager-calls.
    /// </summary>
    internal sealed class FaxConfiguration
    {
        #region Properties

        internal string FaxPath { get; private set; }
        internal string ArchivePath { get; private set; }
        internal string AnalysisPath { get; private set; }
        internal OcrSoftware OCRSoftware { get; private set; }
        internal string OCRSoftwarePath { get; private set; }
        internal string AlarmFaxParserAlias { get; private set; }
        private Dictionary<string, string> ReplaceDictionary { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FaxConfiguration"/> class.
        /// </summary>
        public FaxConfiguration()
        {
            this.FaxPath = SettingsManager.Instance.GetSetting("FaxAlarmSource", "FaxPath").GetString();
            this.ArchivePath = SettingsManager.Instance.GetSetting("FaxAlarmSource", "ArchivePath").GetString();
            this.AnalysisPath = SettingsManager.Instance.GetSetting("FaxAlarmSource", "AnalysisPath").GetString();
            this.AlarmFaxParserAlias = SettingsManager.Instance.GetSetting("FaxAlarmSource", "AlarmfaxParser").GetString();

            string ocr = SettingsManager.Instance.GetSetting("FaxAlarmSource", "OCR.Software").GetString();
            this.OCRSoftware = (OcrSoftware)Enum.Parse(typeof(OcrSoftware), ocr);
            this.OCRSoftwarePath = SettingsManager.Instance.GetSetting("FaxAlarmSource", "OCR.Path").GetString();

            // Parse replace dictionary
            this.ReplaceDictionary = new Dictionary<string, string>(16);

            string replaceDictionaryRaw = SettingsManager.Instance.GetSetting("FaxAlarmSource", "ReplaceDictionary").GetString();
            XDocument doc = XDocument.Parse(replaceDictionaryRaw);

            foreach (XElement rpn in doc.Root.Elements())
            {
                this.ReplaceDictionary[rpn.Attribute("Old").Value] = rpn.Attribute("New").Value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Processes the given line and replaces its contents according to the ReplaceDictionary.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        internal string PerformReplace(string line)
        {
            foreach (var pair in this.ReplaceDictionary)
            {
                line = line.Replace(pair.Key, pair.Value);
            }
            return line;
        }

        #endregion
    }
}
