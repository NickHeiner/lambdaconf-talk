﻿module JsAstToJs

open EdgeJs

let jsAstToJs _ = 
    let edgeFunc = Edge.Func @"
        var escodegen = require('escodegen');

        return function(jsAstStr, cb) {
            var jsAst = JSON.parse(jsAstStr),
                generatedCode = escodegen.generate(jsAst);

            return cb(null, generatedCode);
        };
    "

    let task = edgeFunc.Invoke """{"type": "ExpressionStatement", "expression": {"type": "Literal", "value": true}}"""
    task |> Async.AwaitTask |> ignore
    task.Result