using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks.Dataflow;

namespace RealTimeFraudSight.FraudLensService.Pipeline
{
    public abstract class PipelineFilter :
    IPropagatorBlock<PipelineContext, PipelineContext>,
    ITargetBlock<PipelineContext>,
    ISourceBlock<PipelineContext>,
    IDataflowBlock,
    IReceivableSourceBlock<PipelineContext>
    {
        private readonly TransformBlock<PipelineContext, PipelineContext> _transformBlock;

        public PipelineFilter()
        {
            _transformBlock = new TransformBlock<PipelineContext, PipelineContext>(new Func<PipelineContext, Task<PipelineContext>>(this.ExecutePipeline));
        }
        
        public Task Completion => this._transformBlock.Completion;

        protected abstract Task<PipelineContext> ExecutePipeline(PipelineContext context);

        public void Complete()
        {
            throw new NotImplementedException();
        }

        public PipelineContext? ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<PipelineContext> target, out bool messageConsumed)
        {
            throw new NotImplementedException();
        }

        public void Fault(Exception exception)
        {
            throw new NotImplementedException();
        }

        public IDisposable LinkTo(ITargetBlock<PipelineContext> target, DataflowLinkOptions linkOptions)
        {
            throw new NotImplementedException();
        }

        public DataflowMessageStatus OfferMessage(DataflowMessageHeader messageHeader, PipelineContext messageValue, ISourceBlock<PipelineContext>? source, bool consumeToAccept)
        {
            throw new NotImplementedException();
        }

        public void ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<PipelineContext> target)
        {
            throw new NotImplementedException();
        }

        public bool ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<PipelineContext> target)
        {
            throw new NotImplementedException();
        }

        public bool TryReceive(Predicate<PipelineContext>? filter, [MaybeNullWhen(false)] out PipelineContext item)
        {
            throw new NotImplementedException();
        }

        public bool TryReceiveAll([NotNullWhen(true)] out IList<PipelineContext>? items)
        {
            throw new NotImplementedException();
        }
    }
}