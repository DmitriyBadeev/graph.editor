import { INodeData, Link } from "./types"

const seed = '0.08452418071761225:1642337330146'

// https://visjs.github.io/vis-network/docs/network/
export const graphOptions = {
    physics: {
        solver: 'forceAtlas2Based',
        forceAtlas2Based: {
            gravitationalConstant: -800
        }
    },
    layout: {
        randomSeed: seed
    },
    interaction: {
        hover: true,
    },
    nodes: {
        shape: "dot",
        size: 28,
        font: {
            size: 24,
            color: "#222",
        },
        borderWidth: 0,
        color: {
            background: "#2291FF",
            hover: {
                background: "#156ABE",
            },
            highlight: {
                background: "#1261AE",
            }
        }
    },
    edges: {
        arrowStrikethrough: true,
        width: 4,
        color: {
            color: "#8FCDFF",
            opacity: 0.5,
            hover: "#51ADFF",
            highlight: "#1261AE"
        },
        arrows: {
            to: {
                type: 'arrow',
                scaleFactor: 1.2
            },
            from: {
                type: 'arrow',
                scaleFactor: 1.2
            }
        }
    },
}

export const generateEdges = (links: Link[]) => {
    return links.map(t => ({from: t.source, to: t.destination}))
}

export const generateNodes = (data: INodeData[]) => {
    return data.map(t => ({id: t.id, label: t.name}))
}