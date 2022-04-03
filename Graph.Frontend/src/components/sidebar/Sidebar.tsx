import React, { useEffect } from 'react'
import styled from 'styled-components'
import { Title } from '../typography/Title'
import { Divider } from '../Divider'
import { useQuery } from 'react-query'
import api from '../../utils/api'
import { Loader } from '@skbkontur/react-ui'
import { GraphItem, ListGraphContainer, SidebarContainer } from './styled'

type GraphInfo = {
    id: string
    name: string
}

type Props = {
    selectGraph: (id: string) => void
    activeGraphId: string | null
}

const query = async () => {
    const response = await api.get<GraphInfo[]>('/graph')

    return response?.data
}

export const Sibebar: React.FC<Props> = ({ selectGraph, activeGraphId }) => {
    const { data, isLoading } = useQuery(['graphs'], query)

    useEffect(() => {
        if (data) {
            const firstGraph = data[0]
            selectGraph(firstGraph?.id)
        }
    }, [data])

    const getGraphItems = () => data?.map(graph => (
        <GraphItem key={graph.id} onClick={() => selectGraph(graph.id)} active={graph.id === activeGraphId}>
            {graph.name}
        </GraphItem>
    ))

    return (
        <SidebarContainer>
            <Title level={3}>Графы</Title>
            <Divider />
            <ListGraphContainer>
                <Loader type="normal" active={isLoading}>
                    {getGraphItems()}
                </Loader>
            </ListGraphContainer>
        </SidebarContainer>
    )
}