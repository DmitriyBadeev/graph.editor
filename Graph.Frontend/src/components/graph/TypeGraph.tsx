import { Loader } from '@skbkontur/react-ui'
import React from 'react'
import VisGraph from 'react-graph-vis'
import { generateEdges, generateNodes, graphOptions } from './utils'
import { Props } from './types'
import { useGraphQuery } from './graphRepository'

export const TypeGraph: React.FC<Props> = ({ graphId }) => {
    const { graphData, isLoading } = useGraphQuery(graphId)

    const getGraph = () => {
        const nodes = generateNodes(graphData?.elementsTypes || [])
        const edges = generateEdges(graphData?.typesLinks || [])

        return { nodes, edges }
    }

    return (
        <Loader type="normal" active={isLoading}>
            <VisGraph
                style={{
                    width: "100%",
                    height: "60vh",
                    background: "#fafafa",
                    border: "solid 1px rgba(0,0,0,.1)",
                    borderRadius: "3px"
                }}
                graph={getGraph()}
                options={graphOptions}
            />

        </Loader>
    )
}
