import React from 'react'
import BannerAnim, { Element } from 'rc-banner-anim';
import TweenOne from 'rc-tween-one';
import 'rc-banner-anim/assets/index.css';

export default function () {
    const BgElement = Element.BgElement;
    return (
        <BannerAnim prefixCls="banner-user">
            <Element
                prefixCls="banner-user-elem"
                followParallax={{
                    delay: 1000,
                    data: [
                        { id: 'title', value: 60, type: 'x' },
                        { id: 'content', value: -40, type: 'x' },
                    ],
                }}
                key="0">
                <BgElement
                    key="bg"
                    className="bg"
                    style={{
                        background: '#364D79',
                    }} />
                <TweenOne id="title" className="banner-user-title" animation={{ y: 30, opacity: 0, type: 'from' }}>
                    我：多拉(wdora.com)
                </TweenOne>
                <TweenOne id="content" className="banner-user-text"
                    animation={{ y: 30, opacity: 0, type: 'from', delay: 100 }}
                >
                    认真、真诚、诚实、不作恶......
                </TweenOne>
            </Element>
            <Element
                prefixCls="banner-user-elem"
                key="1"
                followParallax={{
                    delay: 1000,
                    data: [
                        { id: 'title', value: 60, type: 'x' },
                        { id: 'content', value: -40, type: 'x' },
                    ],
                }}
            >
                <BgElement
                    key="bg"
                    className="bg"
                    style={{
                        background: '#64CBCC',
                    }}
                />
                <TweenOne id="title" className="banner-user-title" animation={{ y: 30, opacity: 0, type: 'from' }}>
                    世界那么大！
                  </TweenOne>
                <TweenOne id="content" className="banner-user-text"
                    animation={{ y: 30, opacity: 0, type: 'from', delay: 100 }}
                >
                    如果没有梦想，和咸鱼有什么区别？
                </TweenOne>
            </Element>
        </BannerAnim>);
}