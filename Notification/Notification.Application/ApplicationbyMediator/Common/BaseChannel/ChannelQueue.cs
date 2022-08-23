﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.Common.BaseChannel
{
    public class ChannelQueue<TMessage> where TMessage : class
    {
        private Channel<TMessage> _serviceChannel;


        public ChannelQueue()
        {
            _serviceChannel = Channel.CreateBounded<TMessage>(new BoundedChannelOptions(4000)
            {
                SingleReader = false,
                SingleWriter = false,
                FullMode = BoundedChannelFullMode.Wait
            });
        }


        public async Task AddToChannelAsync(TMessage model, CancellationToken cancellationToken)
        {
            await _serviceChannel.Writer.WriteAsync(model, cancellationToken);
             
        }


        public IAsyncEnumerable<TMessage> ReturnValue(CancellationToken cancellationToken)
        {
            return _serviceChannel.Reader.ReadAllAsync(cancellationToken);
        }
       
        //public int count(CancellationToken cancellationToken)
        //{
        //    int i = 0; 
        //    foreach (var item in ReturnValue(cancellationToken))
        //        i++;
        //    return i;
        //}


        //public async Task AddToChannelAsync(TMessage model)
        //{
        //    await _serviceChannel.Writer.WriteAsync(model);
        //}

        //public IAsyncEnumerable<TMessage> ReturnValue(CancellationToken )
        //{
        //    return _serviceChannel.Reader.ReadAllAsync(cancellationToken);
        //}
    }
}
