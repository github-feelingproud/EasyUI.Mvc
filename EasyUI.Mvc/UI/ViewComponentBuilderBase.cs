﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EasyUI.Mvc.Extensions;
using EasyUI.Mvc.Infrastructure;

namespace EasyUI.Mvc.UI
{
    /// <summary>
    /// View component Builder base class.
    /// </summary>
    public abstract class ViewComponentBuilderBase<TViewComponent, TBuilder> : ComponentBuilderBase<TViewComponent, TBuilder>
        where TViewComponent : ViewComponentBase
        where TBuilder : ViewComponentBuilderBase<TViewComponent, TBuilder>
    {
        private TViewComponent component;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewComponentBuilderBase&lt;TViewComponent, TBuilder&gt;"/> class.
        /// </summary>
        /// <param name="component">The component.</param>
        protected ViewComponentBuilderBase(TViewComponent component)
        {
            Guard.IsNotNull(component, "component");
            this.component = component;
        }

        /// <summary>
        /// Gets the view component.
        /// </summary>
        /// <value>The component.</value>
        protected internal TViewComponent Component
        {
            get
            {
                return component;
            }
            set
            {
                component = value;
            }
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="EasyUI.Mvc.UI.ViewComponentBuilderBase&lt;TViewComponent,TBuilder&gt;"/> to TViewComponent.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator TViewComponent(ViewComponentBuilderBase<TViewComponent, TBuilder> builder)
        {
            Guard.IsNotNull(builder, "builder");

            return builder.ToComponent();
        }

        /// <summary>
        /// Returns the internal view component.
        /// </summary>
        /// <returns></returns>
        public TViewComponent ToComponent()
        {
            return Component;
        }

        /// <summary>
        /// Sets the name of the component.
        /// </summary>
        /// <param name="componentName">The name.</param>
        /// <returns></returns>
        public virtual TBuilder Name(string componentName)
        {
            Component.Name = componentName;

            return this as TBuilder;
        }

        /// <summary>
        /// Sets the HTML attributes.
        /// </summary>
        /// <param name="attributes">The HTML attributes.</param>
        /// <returns></returns>
        public virtual TBuilder HtmlAttributes(object attributes)
        {
            return HtmlAttributes(attributes.ToDictionary());
        }

        /// <summary>
        /// Sets the HTML attributes.
        /// </summary>
        /// <param name="attributes">The HTML attributes.</param>
        /// <returns></returns>
        public virtual TBuilder HtmlAttributes(IDictionary<string, object> attributes)
        {
            Guard.IsNotNull(attributes, "attributes");

            Component.HtmlAttributes.Clear();
            Component.HtmlAttributes.Merge(attributes);

            return this as TBuilder;
        }

        /// <summary>
        /// Sets the options.
        /// </summary>
        /// <param name="options">The options</param>
        /// <returns></returns>
        public virtual TBuilder Options(object options)
        {
            return this.Options(options.ToDictionary());
        }

        /// <summary>
        /// Sets the options.
        /// </summary>
        /// <param name="options">The options</param>
        /// <returns></returns>
        public virtual TBuilder Options(IDictionary<string, object> options)
        {
            Guard.IsNotNull(options, "options");

            Component.Options.Clear();
            Component.Options.Merge(options);

            return this as TBuilder;
        }

        /// <summary>
        /// Renders the component.
        /// </summary>
        public virtual void Render()
        {
            Component.Render();
        }

        public string ToHtmlString()
        {
            return ToComponent().ToHtmlString();
        }

        public override string ToString()
        {
            return ToHtmlString();
        }
    }
}