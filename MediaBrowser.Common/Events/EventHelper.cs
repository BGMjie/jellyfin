﻿using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MediaBrowser.Common.Events
{
    // TODO: @bond Remove
    /// <summary>
    /// Class EventHelper
    /// </summary>
    public static class EventHelper
    {
        /// <summary>
        /// Fires the event.
        /// </summary>
        /// <param name="handler">The handler.</param>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="EventArgs" /> instance containing the event data.</param>
        /// <param name="logger">The logger.</param>
        public static void QueueEventIfNotNull(EventHandler handler, object sender, EventArgs args, ILogger logger)
        {
            if (handler != null)
            {
                Task.Run(() =>
                {
                    try
                    {
                        handler(sender, args);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "Error in event handler");
                    }
                });
            }
        }

        /// <summary>
        /// Queues the event.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="handler">The handler.</param>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The args.</param>
        /// <param name="logger">The logger.</param>
        public static void QueueEventIfNotNull<T>(EventHandler<T> handler, object sender, T args, ILogger logger)
        {
            if (handler != null)
            {
                Task.Run(() =>
                {
                    try
                    {
                        handler(sender, args);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "Error in event handler");
                    }
                });
            }
        }
    }
}