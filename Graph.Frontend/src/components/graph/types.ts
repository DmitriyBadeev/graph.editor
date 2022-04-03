export type Graph = {
    id: string
    name: string
    elements: Element[]
    elementsTypes: ElementType[]
    links: Link[]
    typesLinks: Link[]
}

export type Link = {
    destination: string
    source: string
}

export type ElementType = {
    id: string
    name: string
}

export type Props = {
    graphId: string | null
}

export type Element = {
    id: string,
    name: string,
    type: ElementType
}

export interface INodeData {
    id: string,
    name: string
}