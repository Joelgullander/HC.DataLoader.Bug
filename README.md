### Bug 1: (Solved)
When querying without the TypeExtended field, everything works fine:
```
query {
    foo(fooId: "af83d886-bfa4-4c4e-18bd-08dcdd6a18db") {
         id
         name
    }
}
```

When querying with the TypeExtended field, we expect an error:
```
query {
    foo(fooId: "af83d886-bfa4-4c4e-18bd-08dcdd6a18db") {
         id
         name
         totalBarCount
    }
}
```

Error: 

```
System.InvalidOperationException: Duplicate property.
   at HotChocolate.Execution.Projections.PropertyNodeContainer.AddNode(PropertyNode newNode)
   at HotChocolate.Execution.Projections.SelectionExpressionBuilder.CollectSelections(Context context, ISelectionSet selectionSet, PropertyNodeContainer parent)
   at HotChocolate.Execution.Projections.SelectionExpressionBuilder.BuildExpression[TRoot](ISelection selection)
   at GreenDonut.Projections.HotChocolateExecutionDataLoaderExtensions.<>c__5`2.<GetOrCreateExpression>b__5_0(String _, ValueTuple`2 ctx)
   at HotChocolate.Execution.Processing.Operation.GetOrAddState[TState,TContext](String key, Func`3 createState, TContext context)
   at GreenDonut.Projections.HotChocolateExecutionDataLoaderExtensions.GetOrCreateExpression[TKey,TValue](ISelection selection)
   at GreenDonut.Projections.HotChocolateExecutionDataLoaderExtensions.Select[TKey,TValue](IDataLoader`2 dataLoader, ISelection selection)
   at TestDataLoader.GraphQL.Query.GetFooAsync(IFooByIdDataLoader dataLoader, Guid fooId, ISelection selection, CancellationToken ct) in /Users/joelgullander/ddsthlm/RGS/TestDataLoader/TestDataLoader/TestDataLoader/GraphQL/Query.cs:line 19
   at lambda_method98(Closure, IResolverContext)
   at HotChocolate.Types.Helpers.FieldMiddlewareCompiler.<>c__DisplayClass9_0.<<CreateResolverMiddleware>b__0>d.MoveNext()
```


### Bug 2: 
When querying a nullable object, an error is raised.

Working query:

```
query {
  foo(fooId: "335950de-18fd-4b49-8e0e-c01516c5ef0f") {
    totalBarCount
  }
}
```

Failing query:
```
query {
  foo(fooId: "335950de-18fd-4b49-8e0e-c01516c5ef0f") {
    totalBarCount
    baz {
      id
    }
  }
}
```

Baz is nullable:
```public Baz? Baz { get; set; }```