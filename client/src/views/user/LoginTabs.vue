<template>
  <a-tabs v-model:activeKey="activeKey">
    <a-tab-pane key="1" tab="Tab 1">
        <a-form-item name="username">
          <a-input :rules='rules'  placeholder="Basic usage" v-model:value="userName">
          <template #prefix>
           <UserOutlined />
          </template>
          <template #suffix>
            <a-tooltip title="Extra information">
              <info-circle-outlined style="color: rgba(0, 0, 0, 0.45)" />
            </a-tooltip>
          </template>
        </a-input>
        </a-form-item>
      <a-input placeholder="Basic usage" v-model:value="userName">
          <template #prefix>
           <LockOutlined />
          </template>
          <template #suffix>
            <a-tooltip title="Extra information">
           <EyeInvisibleOutlined />
            </a-tooltip>
          </template>
        </a-input>
    </a-tab-pane>
    <a-tab-pane key="2" tab="Tab 2" force-render>
      <div class="components-input-demo-presuffix">
        <a-input placeholder="Basic usage" v-model:value="userName">
          <template #prefix>
            <user-outlined type="user" />
          </template>
          <template #suffix>
            <a-tooltip title="Extra information">
              <info-circle-outlined style="color: rgba(0, 0, 0, 0.45)" />
            </a-tooltip>
          </template>
        </a-input>
        <br />
        <br />
        <a-input prefix="￥" suffix="RMB" />
      </div>
    </a-tab-pane>
  </a-tabs>
</template>


<script lang="ts" scoped>
import { defineComponent, ref } from "vue";
import { UserOutlined, InfoCircleOutlined,LockOutlined,EyeInvisibleOutlined } from "@ant-design/icons-vue";
export default defineComponent({
  components: {
    UserOutlined,
    InfoCircleOutlined,
    LockOutlined,
    EyeInvisibleOutlined
  },
  setup() {
    const userName = ref("");
    const rules={
       username:[
        {required:true,message:'必须',trigger:'blur'}
      ]
    }
    return {
      userName,
      activeKey: ref("1"),
      rules
    };
  },
});
</script>

