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

        public void Complete()
        {
            throw new NotImplementedException();
        }

        public FlowContext? ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<FlowContext> target, out bool messageConsumed)
        {
            throw new NotImplementedException();
        }

        public void Fault(Exception exception)
        {
            throw new NotImplementedException();
        }

        public IDisposable LinkTo(ITargetBlock<FlowContext> target, DataflowLinkOptions linkOptions)
        {
            throw new NotImplementedException();
        }

        public DataflowMessageStatus OfferMessage(DataflowMessageHeader messageHeader, FlowContext messageValue, ISourceBlock<FlowContext>? source, bool consumeToAccept)
        {
            throw new NotImplementedException();
        }

        public void ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<FlowContext> target)
        {
            throw new NotImplementedException();
        }

        public bool ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<FlowContext> target)
        {
            throw new NotImplementedException();
        }

        public bool TryReceive(Predicate<FlowContext>? filter, [MaybeNullWhen(false)] out FlowContext item)
        {
            throw new NotImplementedException();
        }

        public bool TryReceiveAll([NotNullWhen(true)] out IList<FlowContext>? items)
        {
            throw new NotImplementedException();
        }
    }
}