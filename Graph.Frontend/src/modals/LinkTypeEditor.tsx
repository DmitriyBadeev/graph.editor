import { Button, ComboBox, ComboBoxItem, Gapped, Input } from "@skbkontur/react-ui"
import { FormEvent } from "react"
import styled from "styled-components"
import { Label, LabelText } from "../components/form/styled"
import { useGraphQuery } from "../components/graph/graphRepository"
import { Modal } from "../components/modal/Modal"
import { CommonModalContentProps } from "../components/modal/types"

const Form = styled.form``

type Props = { graphId: string | null } & CommonModalContentProps

export const LinkTypeEditor: React.FC<Props> = ({ graphId, onClose }) => {
    const { graphData } = useGraphQuery(graphId)

    const handleSubmit = (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault()
    }

    const getTypes = async (query: string) => {        
        const items: ComboBoxItem[] = graphData?.elementsTypes.map(t => ({ label: t.name, value: t.id })) || []
        const filtered = items.filter(i => i.label.startsWith(query))

        return filtered
    }

    const getElementType = (id: string): ComboBoxItem | undefined => {
        const elementType = graphData?.elementsTypes.find(t => t.id === id)

        if (elementType) {
            return { label: elementType.name, value: elementType.id }
        }

    }

    const getElementTypes = () => {
        return graphData?.typesLinks.map(typeLink => (
            <Gapped gap={30}>
                <Label>
                    <LabelText>Тип элемента (от):</LabelText>
                    <ComboBox
                        value={getElementType(typeLink.source)} 
                        onValueChange={() => {}} 
                        getItems={getTypes}
                        style={{width: '100%'}}
                        placeholder="Тип элемента (от)"
                    />
                </Label>

                <Label>
                    <LabelText>Тип элемента (до):</LabelText>
                    <ComboBox
                        value={getElementType(typeLink.destination)} 
                        onValueChange={() => {}} 
                        getItems={getTypes}
                        style={{width: '100%'}}
                        placeholder="Тип элемента (до)"
                    />
                </Label>
            </Gapped>
        ))
    }

    return (
        <Form onSubmit={handleSubmit}>
            
            <Modal.Header>Редактирование связей типов елементов</Modal.Header>
            <Modal.Content>
                {getElementTypes()}
            </Modal.Content>

            <Modal.Footer>
                <Gapped>
                    <Button use='primary' type="submit" loading={false}>Сохранить</Button>
                    <Button onClick={onClose}>Отменить</Button>
                </Gapped>
            </Modal.Footer>
        </Form>
    )
}