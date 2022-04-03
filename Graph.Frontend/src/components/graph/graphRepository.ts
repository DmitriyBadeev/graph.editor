import { useQuery } from "react-query"
import api from "../../utils/api"
import { Graph } from "./types"

const graphQuery = async (graphId: string | null) => {
    if (graphId === null) {
        return null
    }

    const response = await api.get<Graph>(`/graph/${graphId}`)
    return response?.data
}

export const useGraphQuery = (graphId: string | null) => {
    const { data: graphData, isLoading } = useQuery(['graphs', graphId], () => graphQuery(graphId) )

    return { graphData, isLoading };
}