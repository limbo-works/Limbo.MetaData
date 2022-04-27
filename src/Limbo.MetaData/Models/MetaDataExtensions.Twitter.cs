using System;
using Limbo.MetaData.Models.Twitter;

// ReSharper disable MethodOverloadWithOptionalParameter

namespace Limbo.MetaData.Models {
    
    public static partial class MetaDataExtensions {

        /// <summary>
        /// Sets the Twitter card of <paramref name="metaData"/> to <paramref name="card"/>.
        /// </summary>
        /// <typeparam name="TMeta">The type of the meta data instance.</typeparam>
        /// <param name="metaData">The current meta data instance.</param>
        /// <param name="card">The Twitter card.</param>
        /// <returns><paramref name="metaData"/> - useful for method chaining.</returns>
        public static TMeta SetTwitterCard<TMeta>(this TMeta metaData, ITwitterCard card) where TMeta : MetaData {
            if (metaData == null) return null;
            metaData.TwitterCard = card;
            return metaData;
        }

        /// <summary>
        /// Sets the Twitter card of <paramref name="metaData"/> to a new instance of <typeparamref name="TCard"/> and
        /// invokes the specified <paramref name="action"/> for updating the card.
        /// </summary>
        /// <typeparam name="TMeta">The type of the <paramref name="metaData"/> instance.</typeparam>
        /// <typeparam name="TCard">The type of the Twitter card.</typeparam>
        /// <param name="metaData">The meta data instance.</param>
        /// <param name="action">The action used for updating the card.</param>
        /// <returns><paramref name="metaData"/> - useful for method chaining.</returns>
        public static TMeta SetTwitterCard<TMeta, TCard>(this TMeta metaData, Action<TCard> action) where TMeta : MetaData where TCard : ITwitterCard {
            if (metaData == null || action == null) return metaData;
            TCard card = Activator.CreateInstance<TCard>();
            action(card);
            metaData.TwitterCard = card;
            return metaData;
        }

        /// <summary>
        /// Sets the Twitter card of <paramref name="metaData"/> to a new instance of <typeparamref name="TCard"/> and
        /// invokes the specified <paramref name="action"/> for updating the card.
        /// </summary>
        /// <typeparam name="TMeta">The type of the <paramref name="metaData"/> instance.</typeparam>
        /// <typeparam name="TInput">The type of the input value.</typeparam>
        /// <typeparam name="TCard">The type of the Twitter card.</typeparam>
        /// <param name="metaData">The meta data instance.</param>
        /// <param name="input">An input value of type <typeparamref name="TInput"/> that is passed along to <paramref name="action"/>.</param>
        /// <param name="action">The action used for updating the card.</param>
        /// <returns>The meta data instance. Useful for method chaining.</returns>
        public static TMeta SetTwitterCard<TMeta, TInput, TCard>(this TMeta metaData, TInput input, Action<TInput, TCard> action) where TMeta : MetaData where TCard : ITwitterCard {
            if (metaData == null || action == null) return metaData;
            var card = Activator.CreateInstance<TCard>();
            action(input, card);
            metaData.TwitterCard = card;
            return metaData;
        }

        /// <summary>
        /// Sets the Twitter card of <paramref name="metaData"/> to the value returned by the specified <paramref name="function"/>.
        /// </summary>
        /// <typeparam name="TMeta">The type of the <paramref name="metaData"/> instance.</typeparam>
        /// <typeparam name="TInput">The type of the input value.</typeparam>
        /// <param name="metaData">The meta data instance.</param>
        /// <param name="input">An input value of type <typeparamref name="TInput"/> that is passed along to <paramref name="function"/>.</param>
        /// <param name="function">The callback function used for determining the new Twitter card value.</param>
        /// <returns>The meta data instance. Useful for method chaining.</returns>
        public static TMeta SetTwitterCard<TMeta, TInput>(this TMeta metaData, TInput input, Func<TInput, ITwitterCard> function) where TMeta : MetaData {
            if (metaData == null || function == null) return metaData;
            var card = function(input);
            metaData.TwitterCard = card;
            return metaData;
        }

        /// <summary>
        /// Sets the Twitter card of <paramref name="metaData"/> to the value returned by the specified <paramref name="function"/>.
        /// </summary>
        /// <typeparam name="TMeta">The type of the <paramref name="metaData"/> instance.</typeparam>
        /// <typeparam name="TInput1">The type of the first input value.</typeparam>
        /// <typeparam name="TInput2">The type of the second input value.</typeparam>
        /// <param name="metaData">The meta data instance.</param>
        /// <param name="input1">An input value of type <typeparamref name="TInput1"/> that is passed along to <paramref name="function"/>.</param>
        /// <param name="input2">An input value of type <typeparamref name="TInput2"/> that is passed along to <paramref name="function"/>.</param>
        /// <param name="function">The callback function used for determining the new Twitter card value.</param>
        /// <returns>The meta data instance. Useful for method chaining.</returns>
        public static TMeta SetTwitterCard<TMeta, TInput1, TInput2>(this TMeta metaData, TInput1 input1, TInput2 input2, Func<TInput1, TInput2, ITwitterCard> function) where TMeta : MetaData {
            if (metaData == null || function == null) return metaData;
            var card = function(input1, input2);
            metaData.TwitterCard = card;
            return metaData;
        }

        /// <summary>
        /// Sets the Twitter card of <paramref name="metaData"/> to the value returned by the specified <paramref name="function"/>.
        /// </summary>
        /// <typeparam name="TMeta">The type of the <paramref name="metaData"/> instance.</typeparam>
        /// <typeparam name="TInput1">The type of the first input value.</typeparam>
        /// <typeparam name="TInput2">The type of the second input value.</typeparam>
        /// <typeparam name="TInput3">The type of the third input value.</typeparam>
        /// <param name="metaData">The meta data instance.</param>
        /// <param name="input1">An input value of type <typeparamref name="TInput1"/> that is passed along to <paramref name="function"/>.</param>
        /// <param name="input2">An input value of type <typeparamref name="TInput2"/> that is passed along to <paramref name="function"/>.</param>
        /// <param name="input3">An input value of type <typeparamref name="TInput3"/> that is passed along to <paramref name="function"/>.</param>
        /// <param name="function">The callback function used for determining the new Twitter card value.</param>
        /// <returns>The meta data instance. Useful for method chaining.</returns>
        public static TMeta SetTwitterCard<TMeta, TInput1, TInput2, TInput3>(this TMeta metaData, TInput1 input1, TInput2 input2, TInput3 input3, Func<TInput1, TInput2, TInput3, ITwitterCard> function) where TMeta : MetaData {
            if (metaData == null || function == null) return metaData;
            var card = function(input1, input2, input3);
            metaData.TwitterCard = card;
            return metaData;
        }

        /// <summary>
        /// Sets the Twitter card of <paramref name="metaData"/> to the value returned by the specified <paramref name="function"/>.
        /// </summary>
        /// <typeparam name="TMeta">The type of the <paramref name="metaData"/> instance.</typeparam>
        /// <typeparam name="TInput1">The type of the first input value.</typeparam>
        /// <typeparam name="TInput2">The type of the second input value.</typeparam>
        /// <typeparam name="TInput3">The type of the third input value.</typeparam>
        /// <typeparam name="TInput4">The type of the fourth input value.</typeparam>
        /// <param name="metaData">The meta data instance.</param>
        /// <param name="input1">An input value of type <typeparamref name="TInput1"/> that is passed along to <paramref name="function"/>.</param>
        /// <param name="input2">An input value of type <typeparamref name="TInput2"/> that is passed along to <paramref name="function"/>.</param>
        /// <param name="input3">An input value of type <typeparamref name="TInput3"/> that is passed along to <paramref name="function"/>.</param>
        /// <param name="input4">An input value of type <typeparamref name="TInput4"/> that is passed along to <paramref name="function"/>.</param>
        /// <param name="function">The callback function used for determining the new Twitter card value.</param>
        /// <returns>The meta data instance. Useful for method chaining.</returns>
        public static TMeta SetTwitterCard<TMeta, TInput1, TInput2, TInput3, TInput4>(this TMeta metaData, TInput1 input1, TInput2 input2, TInput3 input3, TInput4 input4, Func<TInput1, TInput2, TInput3, TInput4, ITwitterCard> function) where TMeta : MetaData {
            if (metaData == null || function == null) return metaData;
            var card = function(input1, input2, input3, input4);
            metaData.TwitterCard = card;
            return metaData;
        }

    }

}