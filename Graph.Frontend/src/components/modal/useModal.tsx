import { useCallback, useState } from "react"
import { Modal } from "./Modal"
import { CommonModalContentProps, ModalProps } from './types'

export function useModal<T>(
    ModalContent: React.FC<T & CommonModalContentProps>,
    contentProps: T,
    modalProps?: Omit<ModalProps, 'onClose' | 'visible'>
) {
    const [opened, setOpened] = useState(false)

    const close = useCallback(() => {
        setOpened(false)
    }, [setOpened])

    const open = useCallback(() => {
        setOpened(true)
    }, [setOpened])

    const modalComponent = (
        <Modal visible={opened} onClose={close} {...modalProps}>
            <ModalContent {...contentProps} onClose={close} />
        </Modal>
    )

    return { modalComponent, close, open }
}