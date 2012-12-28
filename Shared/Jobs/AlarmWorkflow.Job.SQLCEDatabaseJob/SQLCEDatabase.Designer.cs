﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
namespace AlarmWorkflow.Job.SQLCEDatabaseJob
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class SQLCEDatabaseEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new SQLCEDatabaseEntities object using the connection string found in the 'SQLCEDatabaseEntities' section of the application configuration file.
        /// </summary>
        public SQLCEDatabaseEntities() : base("name=SQLCEDatabaseEntities", "SQLCEDatabaseEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new SQLCEDatabaseEntities object.
        /// </summary>
        public SQLCEDatabaseEntities(string connectionString) : base(connectionString, "SQLCEDatabaseEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new SQLCEDatabaseEntities object.
        /// </summary>
        public SQLCEDatabaseEntities(EntityConnection connection) : base(connection, "SQLCEDatabaseEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<OperationData> Operations
        {
            get
            {
                if ((_Operations == null))
                {
                    _Operations = base.CreateObjectSet<OperationData>("Operations");
                }
                return _Operations;
            }
        }
        private ObjectSet<OperationData> _Operations;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Operations EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToOperations(OperationData operationData)
        {
            base.AddObject("Operations", operationData);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="SQLCEDatabaseModel", Name="OperationData")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class OperationData : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new OperationData object.
        /// </summary>
        /// <param name="id">Initial value of the ID property.</param>
        /// <param name="isAcknowledged">Initial value of the IsAcknowledged property.</param>
        /// <param name="timestamp">Initial value of the Timestamp property.</param>
        /// <param name="operationId">Initial value of the OperationId property.</param>
        public static OperationData CreateOperationData(global::System.Guid id, global::System.Boolean isAcknowledged, global::System.DateTime timestamp, global::System.Int32 operationId)
        {
            OperationData operationData = new OperationData();
            operationData.ID = id;
            operationData.IsAcknowledged = isAcknowledged;
            operationData.Timestamp = timestamp;
            operationData.OperationId = operationId;
            return operationData;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// The unique Id. For identifying operations, please use the OperationId!
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        private global::System.Guid _ID;
        partial void OnIDChanging(global::System.Guid value);
        partial void OnIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean IsAcknowledged
        {
            get
            {
                return _IsAcknowledged;
            }
            set
            {
                OnIsAcknowledgedChanging(value);
                ReportPropertyChanging("IsAcknowledged");
                _IsAcknowledged = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IsAcknowledged");
                OnIsAcknowledgedChanged();
            }
        }
        private global::System.Boolean _IsAcknowledged;
        partial void OnIsAcknowledgedChanging(global::System.Boolean value);
        partial void OnIsAcknowledgedChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime Timestamp
        {
            get
            {
                return _Timestamp;
            }
            set
            {
                OnTimestampChanging(value);
                ReportPropertyChanging("Timestamp");
                _Timestamp = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Timestamp");
                OnTimestampChanged();
            }
        }
        private global::System.DateTime _Timestamp;
        partial void OnTimestampChanging(global::System.DateTime value);
        partial void OnTimestampChanged();
    
        /// <summary>
        /// Identifies one Operation.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 OperationId
        {
            get
            {
                return _OperationId;
            }
            set
            {
                OnOperationIdChanging(value);
                ReportPropertyChanging("OperationId");
                _OperationId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("OperationId");
                OnOperationIdChanged();
            }
        }
        private global::System.Int32 _OperationId;
        partial void OnOperationIdChanging(global::System.Int32 value);
        partial void OnOperationIdChanged();
    
        /// <summary>
        /// 
        /// </summary>
        /// <LongDescription>
        /// The binary-serialized contents of the Operation-object.
        /// </LongDescription>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.Byte[] Serialized
        {
            get
            {
                return StructuralObject.GetValidValue(_Serialized);
            }
            set
            {
                OnSerializedChanging(value);
                ReportPropertyChanging("Serialized");
                _Serialized = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Serialized");
                OnSerializedChanged();
            }
        }
        private global::System.Byte[] _Serialized;
        partial void OnSerializedChanging(global::System.Byte[] value);
        partial void OnSerializedChanged();

        #endregion

    
    }

    #endregion

    
}