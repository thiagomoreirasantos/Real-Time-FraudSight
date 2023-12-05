using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks.Dataflow;

namespace RealTimeFraudSight.FraudLensService
{
    public abstract class Flowkeeper :
    IPropagatorBlock<FlowContext, FlowContext>,
    ITargetBlock<FlowContext>,
    ISourceBlock<FlowContext>,
    IDataflowBlock,
    IReceivableSourceBlock<FlowContext>
    {
        private readonly TransformBlock<FlowContext, FlowContext> _transformBlock;

        public Flowkeeper()
        {
            _transformBlock = new TransformBlock<FlowContext, FlowContext>(new Func<FlowContext, Task<FlowContext>>(this.ExecutePipeline));
        }

        public Task Completion => this._transformBlock.Completion;

        protected abstract Task<FlowContext> ExecutePipeline(FlowContext context);

        public void Complete() => this._transformBlock.Complete();

        public FlowContext? ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<FlowContext> target, out bool messageConsumed)
        {
            return ((ISourceBlock<FlowContext>)this._transformBlock).ConsumeMessage(messageHeader, target, out messageConsumed);
        }

        public void Fault(Exception exception)
        {
            ((IDataflowBlock) this._transformBlock).Fault(exception);
        }

        public IDisposable LinkTo(ITargetBlock<FlowContext> target, DataflowLinkOptions linkOptions)
        {
            return this._transformBlock.LinkTo(target, linkOptions);
        }

        public DataflowMessageStatus OfferMessage(DataflowMessageHeader messageHeader, FlowContext messageValue, ISourceBlock<FlowContext>? source, bool consumeToAccept)
        {
            return ((ITargetBlock<FlowContext>)this._transformBlock).OfferMessage(messageHeader, messageValue, source, consumeToAccept);
        }

        public void ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<FlowContext> target)
        {
            ((ISourceBlock<FlowContext>)this._transformBlock).ReleaseReservation(messageHeader, target);
        }

        public bool ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<FlowContext> target)
        {
            return ((ISourceBlock<FlowContext>)this._transformBlock).ReserveMessage(messageHeader, target);
        }

        public bool TryReceive(Predicate<FlowContext>? filter, [MaybeNullWhen(false)] out FlowContext item)
        {
            return this._transformBlock.TryReceive(filter, out item);
        }

        public bool TryReceiveAll([NotNullWhen(true)] out IList<FlowContext>? items)
        {
            return this._transformBlock.TryReceiveAll(out items);
        }
    }
}