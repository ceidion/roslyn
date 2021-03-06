﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CodeActions;

namespace Microsoft.CodeAnalysis
{
    internal class DocumentChangeAction : CodeAction
    {
        private readonly string title;
        private readonly Func<CancellationToken, Task<Document>> createChangedDocument;
        private readonly string equivalenceKey;

        public DocumentChangeAction(string title, Func<CancellationToken, Task<Document>> createChangedDocument, string equivalenceKey = null)
        {
            this.title = title;
            this.createChangedDocument = createChangedDocument;
            this.equivalenceKey = equivalenceKey;
        }

        public override string Title
        {
            get { return this.title; }
        }

        public override string EquivalenceKey
        {
            get { return this.equivalenceKey; }
        }

        protected override Task<Document> GetChangedDocumentAsync(CancellationToken cancellationToken)
        {
            return this.createChangedDocument(cancellationToken);
        }
    }
}
