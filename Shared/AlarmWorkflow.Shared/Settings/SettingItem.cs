﻿using System;
using System.Diagnostics;

namespace AlarmWorkflow.Shared.Settings
{
    /// <summary>
    /// Represents a single setting that was read from the configuration and may have a custom value defined.
    /// </summary>
    [DebuggerDisplay("Name = {Name}, Value = {Value} (is modified = {IsModified}, is default = {IsValueDefault})")]
    public sealed class SettingItem
    {
        #region Fields

        /// <summary>
        /// The type of the setting. This is used to avoid that the user settings invalid values.
        /// </summary>
        private Type _settingType;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the name of this setting.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Gets the current value of this setting.
        /// See documentation for further information.
        /// </summary>
        /// <remarks>To read this setting, please use "GetValue()".
        /// To change this setting, please use "SetValue()".</remarks>
        public object Value { get; private set; }
        /// <summary>
        /// Gets the default value of this setting.
        /// </summary>
        public object DefaultValue { get; private set; }
        /// <summary>
        /// Gets whether or not the value has been modified.
        /// </summary>
        public bool IsModified { get; private set; }
        /// <summary>
        /// Gets the name of the editor that is used to edit this setting.
        /// If this is null or empty, then the default editor for this type is used.
        /// </summary>
        public string EditorName { get; private set; }
        /// <summary>
        /// Gets whether or not the value in this setting is the default value.
        /// </summary>
        public bool IsValueDefault
        {
            get { return object.Equals(Value, DefaultValue); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Prevents a default instance of the <see cref="SettingItem"/> class from being created.
        /// </summary>
        private SettingItem()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingItem"/> class.
        /// </summary>
        /// <param name="name">The name of this setting.</param>
        /// <param name="value">The value of this setting.</param>
        /// <param name="defaultValue">The default value of this setting. Used to reset the setting.</param>
        /// <param name="type">The type of the setting.</param>
        /// <param name="editorName">The name of the editor used to edit this setting.</param>
        internal SettingItem(string name, object value, object defaultValue, Type type, string editorName)
            : this()
        {
            this.Name = name;
            this.Value = value;
            this.DefaultValue = defaultValue;
            _settingType = type;
            this.EditorName = editorName;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the value of this setting casted to its desired type.
        /// </summary>
        /// <typeparam name="T">The type to cast the setting to.</typeparam>
        /// <returns>The value of this setting casted to its desired type. If the value is null then the default value for <typeparamref name="T"/> is returned.</returns>
        public T GetValue<T>()
        {
            if (Value == null)
            {
                return default(T);
            }
            return (T)Value;
        }

        /// <summary>
        /// Returns the value of this setting as a boolean.
        /// </summary>
        /// <returns>The value of this setting as a boolean.</returns>
        public bool GetBoolean()
        {
            return GetValue<bool>();
        }

        /// <summary>
        /// Returns the value of this setting as a string.
        /// </summary>
        /// <returns>The value of this setting as a string.</returns>
        public string GetString()
        {
            return GetValue<string>();
        }

        /// <summary>
        /// Returns the value of this setting as an Int32.
        /// </summary>
        /// <returns>The value of this setting as an Int32.</returns>
        public int GetInt32()
        {
            return GetValue<int>();
        }

        /// <summary>
        /// Sets the value of this setting.
        /// </summary>
        /// <param name="value">The new value of this setting.</param>
        public void SetValue(object value)
        {
            SetValue(value, true);
        }

        /// <summary>
        /// Sets the value of this setting.
        /// </summary>
        /// <param name="value">The new value of this setting.</param>
        /// <param name="setIsModified">Whether or not to set the "IsModified" property if the value is modified.</param>
        internal void SetValue(object value, bool setIsModified)
        {
            // Only set the value if it the types match
            if (value != null && value.GetType().IsSubclassOf(_settingType))
            {
                return;
            }
            if (value == this.Value)
            {
                return;
            }

            this.Value = value;

            if (setIsModified)
            {
                IsModified = true;
            }
        }

        /// <summary>
        /// Sets the value of this setting using a string-representation.
        /// </summary>
        /// <param name="value">The string-value.</param>
        /// <param name="isNull">Whether or not an empty string means null.</param>
        /// <param name="setIsModified"></param>
        internal void SetStringValue(string value, bool isNull, bool setIsModified)
        {
            // Try to convert to new type
            object valueNew = null;
            if (!isNull)
            {
                valueNew = Convert.ChangeType(value, _settingType);
            }
            this.SetValue(valueNew, setIsModified);
        }

        /// <summary>
        /// Resets the value of this setting to its default value.
        /// </summary>
        public void ResetValue()
        {
            // Check if we need to set the "IsModified" flag
            if (this.Value != this.DefaultValue)
            {
                IsModified = true;
            }
            this.Value = this.DefaultValue;
        }

        /// <summary>
        /// Returns whether or not a given <see cref="SettingItem"/> can have a null-value.
        /// </summary>
        /// <param name="settingItem"></param>
        /// <returns></returns>
        public static bool CanBeNull(SettingItem settingItem)
        {
            return !settingItem._settingType.IsValueType;
        }

        #endregion
    }
}
