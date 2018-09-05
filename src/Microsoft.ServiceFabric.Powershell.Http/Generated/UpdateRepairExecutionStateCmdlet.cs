// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Powershell.Http
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.ServiceFabric.Common;

    /// <summary>
    /// Updates the execution state of a repair task.
    /// </summary>
    [Cmdlet(VerbsData.Update, "SFRepairExecutionState", DefaultParameterSetName = "UpdateRepairExecutionState")]
    public partial class UpdateRepairExecutionStateCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets Node flag
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, ParameterSetName = "UpdateRepairExecutionState")]
        public SwitchParameter Node
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets TaskId. The ID of the repair task.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = "UpdateRepairExecutionState")]
        public string TaskId { get; set; }

        /// <summary>
        /// Gets or sets State. The workflow state of the repair task. Valid initial states are Created, Claimed, and
        /// Preparing. Possible values include: 'Invalid', 'Created', 'Claimed', 'Preparing', 'Approved', 'Executing',
        /// 'Restoring', 'Completed'
        /// </summary>
        [Parameter(Mandatory = true, Position = 3, ParameterSetName = "UpdateRepairExecutionState")]
        public State? State { get; set; }

        /// <summary>
        /// Gets or sets Action. The requested repair action. Must be specified when the repair task is created, and is
        /// immutable once set.
        /// </summary>
        [Parameter(Mandatory = true, Position = 4, ParameterSetName = "UpdateRepairExecutionState")]
        public string Action { get; set; }

        /// <summary>
        /// Gets or sets Version. The version of the repair task.
        /// When creating a new repair task, the version must be set to zero.  When updating a repair task,
        /// the version is used for optimistic concurrency checks.  If the version is
        /// set to zero, the update will not check for write conflicts.  If the version is set to a non-zero value, then the
        /// update will only succeed if the actual current version of the repair task matches this value.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ParameterSetName = "UpdateRepairExecutionState")]
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets Description. A description of the purpose of the repair task, or other informational details.
        /// May be set when the repair task is created, and is immutable once set.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ParameterSetName = "UpdateRepairExecutionState")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets Flags. A bitwise-OR of the following values, which gives additional details about the status of the
        /// repair task.
        /// - 1 - Cancellation of the repair has been requested
        /// - 2 - Abort of the repair has been requested
        /// - 4 - Approval of the repair was forced via client request
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ParameterSetName = "UpdateRepairExecutionState")]
        public int? Flags { get; set; }

        /// <summary>
        /// Gets or sets NodeNames. The list of nodes targeted by a repair action.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ParameterSetName = "UpdateRepairExecutionState")]
        public IEnumerable<string> NodeNames { get; set; }

        /// <summary>
        /// Gets or sets Executor. The name of the repair executor. Must be specified in Claimed and later states, and is
        /// immutable once set.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ParameterSetName = "UpdateRepairExecutionState")]
        public string Executor { get; set; }

        /// <summary>
        /// Gets or sets ExecutorData. A data string that the repair executor can use to store its internal state.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ParameterSetName = "UpdateRepairExecutionState")]
        public string ExecutorData { get; set; }

        /// <summary>
        /// Gets or sets NodeImpactList. The list of nodes impacted by a repair action and their respective expected impact.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ParameterSetName = "UpdateRepairExecutionState")]
        public IEnumerable<NodeImpact> NodeImpactList { get; set; }

        /// <summary>
        /// Gets or sets ResultStatus. A value describing the overall result of the repair task execution. Must be specified in
        /// the Restoring and later states, and is immutable once set. Possible values include: 'Invalid', 'Succeeded',
        /// 'Cancelled', 'Interrupted', 'Failed', 'Pending'
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ParameterSetName = "UpdateRepairExecutionState")]
        public ResultStatus? ResultStatus { get; set; }

        /// <summary>
        /// Gets or sets ResultCode. A numeric value providing additional details about the result of the repair task
        /// execution.
        /// May be specified in the Restoring and later states, and is immutable once set.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ParameterSetName = "UpdateRepairExecutionState")]
        public int? ResultCode { get; set; }

        /// <summary>
        /// Gets or sets ResultDetails. A string providing additional details about the result of the repair task execution.
        /// May be specified in the Restoring and later states, and is immutable once set.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ParameterSetName = "UpdateRepairExecutionState")]
        public string ResultDetails { get; set; }

        /// <summary>
        /// Gets or sets CreatedUtcTimestamp. The time when the repair task entered the Created state.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ParameterSetName = "UpdateRepairExecutionState")]
        public DateTime? CreatedUtcTimestamp { get; set; }

        /// <summary>
        /// Gets or sets ClaimedUtcTimestamp. The time when the repair task entered the Claimed state.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ParameterSetName = "UpdateRepairExecutionState")]
        public DateTime? ClaimedUtcTimestamp { get; set; }

        /// <summary>
        /// Gets or sets PreparingUtcTimestamp. The time when the repair task entered the Preparing state.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ParameterSetName = "UpdateRepairExecutionState")]
        public DateTime? PreparingUtcTimestamp { get; set; }

        /// <summary>
        /// Gets or sets ApprovedUtcTimestamp. The time when the repair task entered the Approved state
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ParameterSetName = "UpdateRepairExecutionState")]
        public DateTime? ApprovedUtcTimestamp { get; set; }

        /// <summary>
        /// Gets or sets ExecutingUtcTimestamp. The time when the repair task entered the Executing state
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ParameterSetName = "UpdateRepairExecutionState")]
        public DateTime? ExecutingUtcTimestamp { get; set; }

        /// <summary>
        /// Gets or sets RestoringUtcTimestamp. The time when the repair task entered the Restoring state
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ParameterSetName = "UpdateRepairExecutionState")]
        public DateTime? RestoringUtcTimestamp { get; set; }

        /// <summary>
        /// Gets or sets CompletedUtcTimestamp. The time when the repair task entered the Completed state
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ParameterSetName = "UpdateRepairExecutionState")]
        public DateTime? CompletedUtcTimestamp { get; set; }

        /// <summary>
        /// Gets or sets PreparingHealthCheckStartUtcTimestamp. The time when the repair task started the health check in the
        /// Preparing state.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ParameterSetName = "UpdateRepairExecutionState")]
        public DateTime? PreparingHealthCheckStartUtcTimestamp { get; set; }

        /// <summary>
        /// Gets or sets PreparingHealthCheckEndUtcTimestamp. The time when the repair task completed the health check in the
        /// Preparing state.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ParameterSetName = "UpdateRepairExecutionState")]
        public DateTime? PreparingHealthCheckEndUtcTimestamp { get; set; }

        /// <summary>
        /// Gets or sets RestoringHealthCheckStartUtcTimestamp. The time when the repair task started the health check in the
        /// Restoring state.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ParameterSetName = "UpdateRepairExecutionState")]
        public DateTime? RestoringHealthCheckStartUtcTimestamp { get; set; }

        /// <summary>
        /// Gets or sets RestoringHealthCheckEndUtcTimestamp. The time when the repair task completed the health check in the
        /// Restoring state.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ParameterSetName = "UpdateRepairExecutionState")]
        public DateTime? RestoringHealthCheckEndUtcTimestamp { get; set; }

        /// <summary>
        /// Gets or sets PreparingHealthCheckState. The workflow state of the health check when the repair task is in the
        /// Preparing state. Possible values include: 'NotStarted', 'InProgress', 'Succeeded', 'Skipped', 'TimedOut'
        /// 
        /// Specifies the workflow state of a repair task's health check. This type supports the Service Fabric platform; it is
        /// not meant to be used directly from your code.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ParameterSetName = "UpdateRepairExecutionState")]
        public RepairTaskHealthCheckState? PreparingHealthCheckState { get; set; }

        /// <summary>
        /// Gets or sets RestoringHealthCheckState. The workflow state of the health check when the repair task is in the
        /// Restoring state. Possible values include: 'NotStarted', 'InProgress', 'Succeeded', 'Skipped', 'TimedOut'
        /// 
        /// Specifies the workflow state of a repair task's health check. This type supports the Service Fabric platform; it is
        /// not meant to be used directly from your code.
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ParameterSetName = "UpdateRepairExecutionState")]
        public RepairTaskHealthCheckState? RestoringHealthCheckState { get; set; }

        /// <summary>
        /// Gets or sets PerformPreparingHealthCheck. A value to determine if health checks will be performed when the repair
        /// task enters the Preparing state.
        /// </summary>
        [Parameter(Mandatory = false, Position = 28, ParameterSetName = "UpdateRepairExecutionState")]
        public bool? PerformPreparingHealthCheck { get; set; }

        /// <summary>
        /// Gets or sets PerformRestoringHealthCheck. A value to determine if health checks will be performed when the repair
        /// task enters the Restoring state.
        /// </summary>
        [Parameter(Mandatory = false, Position = 29, ParameterSetName = "UpdateRepairExecutionState")]
        public bool? PerformRestoringHealthCheck { get; set; }

        /// <inheritdoc/>
        protected override void ProcessRecordInternal()
        {
            try
            {
                RepairTargetDescriptionBase repairTargetDescriptionBase = null;
                if (this.Node.IsPresent)
                {
                    repairTargetDescriptionBase = new NodeRepairTargetDescription(
                        nodeNames: this.NodeNames);
                }

                RepairImpactDescriptionBase repairImpactDescriptionBase = null;
                if (this.Node.IsPresent)
                {
                    repairImpactDescriptionBase = new NodeRepairImpactDescription(
                        nodeImpactList: this.NodeImpactList);
                }

                var repairTaskHistory = new RepairTaskHistory(
                createdUtcTimestamp: this.CreatedUtcTimestamp,
                claimedUtcTimestamp: this.ClaimedUtcTimestamp,
                preparingUtcTimestamp: this.PreparingUtcTimestamp,
                approvedUtcTimestamp: this.ApprovedUtcTimestamp,
                executingUtcTimestamp: this.ExecutingUtcTimestamp,
                restoringUtcTimestamp: this.RestoringUtcTimestamp,
                completedUtcTimestamp: this.CompletedUtcTimestamp,
                preparingHealthCheckStartUtcTimestamp: this.PreparingHealthCheckStartUtcTimestamp,
                preparingHealthCheckEndUtcTimestamp: this.PreparingHealthCheckEndUtcTimestamp,
                restoringHealthCheckStartUtcTimestamp: this.RestoringHealthCheckStartUtcTimestamp,
                restoringHealthCheckEndUtcTimestamp: this.RestoringHealthCheckEndUtcTimestamp);

                var repairTask = new RepairTask(
                taskId: this.TaskId,
                state: this.State,
                action: this.Action,
                version: this.Version,
                description: this.Description,
                flags: this.Flags,
                target: repairTargetDescriptionBase,
                executor: this.Executor,
                executorData: this.ExecutorData,
                impact: repairImpactDescriptionBase,
                resultStatus: this.ResultStatus,
                resultCode: this.ResultCode,
                resultDetails: this.ResultDetails,
                history: repairTaskHistory,
                preparingHealthCheckState: this.PreparingHealthCheckState,
                restoringHealthCheckState: this.RestoringHealthCheckState,
                performPreparingHealthCheck: this.PerformPreparingHealthCheck,
                performRestoringHealthCheck: this.PerformRestoringHealthCheck);

                var result = this.ServiceFabricClient.Repairs.UpdateRepairExecutionStateAsync(
                    repairTask: repairTask,
                    cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

                this.WriteObject(this.FormatOutput(result));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <inheritdoc/>
        protected override object FormatOutput(object output)
        {
            return output;
        }
    }
}