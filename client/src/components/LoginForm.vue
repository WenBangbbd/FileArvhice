<template>
  <div id="container">
    <a-form id="loginform" :model="formState" :layout="formState.layout">
      <a-form-item>
        <login-tabs class="logintabs"></login-tabs>
      </a-form-item>
      <a-form-item>
        <a-checkbox v-model:checked="checked">记住密码</a-checkbox>
        <a href="" class="forget"> 忘记密码？</a>
      </a-form-item>
      <a-form-item>
        <a-button type="primary" block>登录</a-button>
      </a-form-item>
      <a-form-item>
        <a href="">Sign in with</a>
        <span class="otherlogin">
          <a href=""><WechatOutlined /></a>
          <a href=""><AlipayCircleOutlined /></a>
          <a href=""><QqOutlined /></a>
        </span>
       <router-link class="signup" :to="{ name: 'register' }">Sign up</router-link>
      </a-form-item>
    </a-form>
  </div>
</template>
<script>
import { defineComponent, reactive, toRaw, ref } from "vue";
import LoginTabls from "./LoginTabs.vue";
import {
  WechatOutlined,
  AlipayCircleOutlined,
  QqOutlined,
} from "@ant-design/icons-vue";
export default defineComponent({
  components: {
    "login-tabs": LoginTabls,
    WechatOutlined,
    AlipayCircleOutlined,
    QqOutlined,
  },
  setup() {
    const formState = reactive({
      name: "",
      region: undefined,
      date1: undefined,
      delivery: false,
      type: [],
      resource: "",
      desc: "",
      layout: "vertical",
    });
    const onSubmit = () => {
      console.log("submit!", toRaw(formState));
    };

    return {
      labelCol: {
        span: 4,
      },
      wrapperCol: {
        span: 14,
      },
      formState,
      onSubmit,
      checked: ref(false),
    };
  },
});
</script>

<style lang="less" scoped>
#container {
  width: 700px;
  margin: 0 auto;
  #loginform {
    .ant-form-item {
      width: 400px;
      margin: 0 auto;
      .otherlogin {
        a {
          margin-left: 20px;
        }
      }
      .signup{
        position: absolute;
        right: 0;
      }
    }
    .ant-form {
      width: 500px;
      display: block;
      margin-top: 0;
      margin-bottom: 0;
      margin: auto;
      .logintabs {
        margin: 10px 20px 20px 20px;
      }
    }
    .forget {
      position: absolute;
      right: 0;
    }
  }
}
</style>