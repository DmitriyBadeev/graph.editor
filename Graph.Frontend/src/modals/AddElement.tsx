import { Button, ComboBox, ComboBoxItem, Gapped, Input } from "@skbkontur/react-ui"
import { FormEvent, useState } from "react"
import { useMutation } from "react-query"
import { queryClient } from "../App"
import { Form, Label, LabelText } from "../components/form/styled"
import { useGraphQuery } from "../components/graph/graphRepository"
import { Modal } from "../components/modal/Modal"
import { CommonModalContentProps } from "../components/modal/types"
import api from "../utils/api"

type Props = { graphId: string | null } & CommonModalContentProps
type AddElementRequestData = { name: string, typeId: string, graphId: string }

const addElement = async ({ name, graphId, typeId }: AddElementRequestData) => {
    const response = await api.post('/element', { name, graphId, typeId })
    await queryClient.invalidateQueries(['graphs', graphId])

    return response.data
}

export const AddElementModal = ({ onClose, graphId }: Props) => {
    const { graphData } = useGraphQuery(graphId)

    const onSuccess = () => {
        onClose()
    }

    const { mutate, isLoading } = useMutation(addElement, { onSuccess })

    const [selectedType, setSelectedType] = useState<ComboBoxItem>()
    const [name, setName] = useState<string>('')

    const getTypes = async (query: string) => {        
        const items: ComboBoxItem[] = graphData?.elementsTypes.map(t => ({ label: t.name, value: t.id })) || []
        const filtered = items.filter(i => i.label.startsWith(query))

        return filtered
    }

    const handleSubmit = (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault()

        if (name && selectedType && graphId) {
            mutate({name, graphId, typeId: selectedType.value})
        }
    }

    const handleChangeName = (e: React.ChangeEvent<HTMLInputElement>) => {
        setName(e.target.value)
    }

    return (
        <Form onSubmit={handleSubmit}>
            <Modal.Header>Добавление элемента</Modal.Header>
            <Modal.Content>
                <Label>
                    <LabelText>Имя элемента:</LabelText>
                    <Input 
                        placeholder="Имя" 
                        value={name}
                        onChange={handleChangeName}
                        style={{width: '100%'}}
                    />
                </Label>

                <Label>
                    <LabelText>Тип элемента:</LabelText>
                    <ComboBox
                        value={selectedType} 
                        onValueChange={setSelectedType} 
                        getItems={getTypes}
                        style={{width: '100%'}}
                        placeholder="Тип элемента"
                    />
                </Label>                
            </Modal.Content>
            <Modal.Footer>
                <Gapped>
                    <Button use='primary' type="submit" loading={isLoading}>Добавить</Button>
                    <Button onClick={onClose}>Отменить</Button>
                </Gapped>
            </Modal.Footer>
        </Form>
    )
}