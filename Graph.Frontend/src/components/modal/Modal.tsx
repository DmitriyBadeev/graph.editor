import { Delete } from '@skbkontur/react-icons'
import { PropsWithChildren, useEffect } from 'react'
import { Title } from '../typography/Title'
import { useScrollBlock } from './useScrollBlock'
import { Overlay, ModalContainer, CrossIconContainer, HeaderContainer, ContentContainer, FooterContainer } from './styles'
import { ModalProps } from './types'

export const Modal = ({ visible, onClose, children }: PropsWithChildren<ModalProps>) => {
    const [blockScroll, allowScroll] = useScrollBlock()
    
    useEffect(() => {
        visible ? blockScroll() : allowScroll()
    }, [visible, blockScroll, allowScroll])

    if (!visible) return null

    return (
        <Overlay>
            <ModalContainer onClick={(e) => e.stopPropagation()}>
                <CrossIconContainer onClick={onClose}>
                    <Delete />
                </CrossIconContainer>
                {children}
            </ModalContainer>
        </Overlay>
    )
}

Modal.Header = ({ children }: PropsWithChildren<{}>) => {
    return <HeaderContainer>
        <Title level={3}>{children}</Title>
    </HeaderContainer>
}

Modal.Content = ({ children }: PropsWithChildren<{}>) => {
    return <ContentContainer>{children}</ContentContainer>
}

Modal.Footer = ({ children }: PropsWithChildren<{}>) => {
    return <FooterContainer>{children}</FooterContainer>
}
